using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SystemModule.Exceptions;
using SystemModule.Sockets.Enum;

namespace SystemModule.CoreSocket
{
    /// <summary>
    /// 消息通知类。内部全为弱引用。
    /// </summary>
    public class AppMessenger
    {
        private static AppMessenger m_instance;
        private readonly ReaderWriterLockSlim m_lockSlim = new ReaderWriterLockSlim();
        private readonly Dictionary<string, List<MessageInstance>> m_tokenAndInstance = new Dictionary<string, List<MessageInstance>>();

        /// <summary>
        /// 默认单例实例
        /// </summary>
        public static AppMessenger Default
        {
            get
            {
                if (m_instance != null)
                {
                    return m_instance;
                }
                lock (typeof(AppMessenger))
                {
                    if (m_instance != null)
                    {
                        return m_instance;
                    }
                    m_instance = new AppMessenger();
                    return m_instance;
                }
            }
        }

        /// <summary>
        /// 允许多广播注册
        /// </summary>
        public bool AllowMultiple { get; set; }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="token"></param>
        /// <param name="messageInstance"></param>
        /// <exception cref="MessageRegisteredException"></exception>
        public void Add(string token, MessageInstance messageInstance)
        {
            using (WriteLock writeLock = new WriteLock(m_lockSlim))
            {
                if (m_tokenAndInstance.ContainsKey(token))
                {
                    if (!AllowMultiple)
                    {
                        throw new MessageRegisteredException(TouchSocketStatus.TokenExisted.GetDescription(token));
                    }
                    m_tokenAndInstance[token].Add(messageInstance);
                }
                else
                {
                    m_tokenAndInstance.Add(token, new List<MessageInstance>()
                {
                    messageInstance
                });
                }
            }
        }

        /// <summary>
        /// 判断能否触发该消息，意味着该消息是否已经注册。
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool CanSendMessage(string token)
        {
            using (ReadLock readLock = new ReadLock(m_lockSlim))
            {
                return m_tokenAndInstance.ContainsKey(token);
            }
        }

        /// <summary>
        /// 清除所有消息
        /// </summary>
        public void Clear()
        {
            using (WriteLock writeLock = new WriteLock(m_lockSlim))
            {
                m_tokenAndInstance.Clear();
            }
        }

        /// <summary>
        /// 获取所有消息
        /// </summary>
        /// <returns></returns>
        public string[] GetAllMessage()
        {
            using (ReadLock readLock = new ReadLock(m_lockSlim))
            {
                return m_tokenAndInstance.Keys.ToArray();
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="token"></param>
        public void Remove(string token)
        {
            using (WriteLock writeLock = new WriteLock(m_lockSlim))
            {
                m_tokenAndInstance.Remove(token);
            }
        }

        /// <summary>
        /// 按对象移除
        /// </summary>
        /// <param name="messageObject"></param>
        public void Remove(IMessageObject messageObject)
        {
            using (WriteLock writeLock = new WriteLock(m_lockSlim))
            {
                List<string> key = new List<string>();

                foreach (string item in m_tokenAndInstance.Keys)
                {
                    foreach (MessageInstance item2 in m_tokenAndInstance[item].ToArray())
                    {
                        if (messageObject == item2.MessageObject)
                        {
                            m_tokenAndInstance[item].Remove(item2);
                            if (m_tokenAndInstance[item].Count == 0)
                            {
                                key.Add(item);
                            }
                        }
                    }
                }

                foreach (string item in key)
                {
                    m_tokenAndInstance.Remove(item);
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="parameters"></param>
        /// <exception cref="MessageNotFoundException"></exception>
        public Task SendAsync(string token, params object[] parameters)
        {
            return EasyTask.Run(() =>
            {
                using (ReadLock readLock = new ReadLock(m_lockSlim))
                {
                    if (m_tokenAndInstance.TryGetValue(token, out List<MessageInstance> list))
                    {
                        List<MessageInstance> clear = new List<MessageInstance>();

                        foreach (MessageInstance item in list)
                        {
                            if (!item.Static && !item.WeakReference.TryGetTarget(out _))
                            {
                                clear.Add(item);
                                continue;
                            }
                            try
                            {
                                item.Invoke(item.MessageObject, parameters);
                            }
                            catch
                            {
                            }
                        }

                        foreach (MessageInstance item in clear)
                        {
                            list.Remove(item);
                        }
                    }
                    else
                    {
                        throw new MessageNotFoundException(TouchSocketStatus.MessageNotFound.GetDescription(token));
                    }
                }
            });
        }

        /// <summary>
        /// 发送消息，当多播时，只返回最后一个返回值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="token"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="MessageNotFoundException"></exception>
        public Task<T> SendAsync<T>(string token, params object[] parameters)
        {
            return EasyTask.Run(() =>
            {
                using (ReadLock readLock = new ReadLock(m_lockSlim))
                {
                    if (m_tokenAndInstance.TryGetValue(token, out List<MessageInstance> list))
                    {
                        T result = default;
                        List<MessageInstance> clear = new List<MessageInstance>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            MessageInstance item = list[i];
                            if (!item.Static && !item.WeakReference.TryGetTarget(out _))
                            {
                                clear.Add(item);
                                continue;
                            }

                            try
                            {
                                if (i == list.Count - 1)
                                {
                                    result = (T)item.Invoke(item.MessageObject, parameters);
                                }
                                else
                                {
                                    item.Invoke(item.MessageObject, parameters);
                                }
                            }
                            catch
                            {
                            }
                        }

                        foreach (MessageInstance item in clear)
                        {
                            list.Remove(item);
                        }
                        return result;
                    }
                    else
                    {
                        throw new MessageNotFoundException(TouchSocketStatus.MessageNotFound.GetDescription(token));
                    }
                }
            });
        }
    }
}