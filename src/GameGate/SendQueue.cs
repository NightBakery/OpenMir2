using GameGate.Services;
using NLog;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GameGate
{
    public class SendQueue
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly Channel<SendSessionMessage> _sendQueue;
        private readonly ServerManager ServerMgr = ServerManager.Instance;

        public SendQueue()
        {
            _sendQueue = Channel.CreateUnbounded<SendSessionMessage>();
        }

        /// <summary>
        /// 获取待发送队列数量
        /// </summary>
        public int QueueCount => _sendQueue.Reader.Count;

        /// <summary>
        /// 添加到发送队列
        /// </summary>
        public void AddClientQueue(SendSessionMessage sessionPacket)
        {
            _sendQueue.Writer.TryWrite(sessionPacket);
        }

        /// <summary>
        /// 消息发送队列
        /// </summary>
        public void StartProcessQueueSend(CancellationToken stoppingToken)
        {
            Task.Factory.StartNew(async () =>
            {
                while (await _sendQueue.Reader.WaitToReadAsync(stoppingToken))
                {
                    if (_sendQueue.Reader.TryRead(out var sendPacket))
                    {
                        try
                        {
                            ServerMgr.Send(sendPacket);
                        }
                        catch (Exception e)
                        {
                            logger.Error(e.StackTrace);
                        }
                        finally
                        {
                            unsafe
                            {
                                NativeMemory.Free(sendPacket.Buffer.ToPointer());
                            }
                            GateShare.PacketMessagePool.Return(sendPacket);
                        }
                    }
                }
            }, stoppingToken);
        }
    }
}