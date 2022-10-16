using System;
using System.Net.Sockets;

namespace SystemModule.Sockets.Event
{
    public class DSCClientDataInEventArgs : EventArgs
    {
        public int BuffLen;
        public readonly Memory<byte> Buff;
        public readonly Socket Socket;
        public int SocketId => (int)Socket.Handle;

        public DSCClientDataInEventArgs(Socket soc, Memory<byte> buff, int buffLen)
        {
            this.Socket = soc;
            this.Buff = buff;
            this.BuffLen = buffLen;
        }
    }
}