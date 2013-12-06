using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace XETA
{
    public class xetaSocket
    {
        private ClientWebSocket socketClient;
        private System.Threading.CancellationTokenSource connectCancel = new System.Threading.CancellationTokenSource();
        private System.Threading.CancellationToken connectCancelToken;
        public byte connectTick = 0;

        //Create a new socket client class
        public xetaSocket(string networkAddress, string networkPort) 
        {
            //Init socket
            socketClient = new ClientWebSocket();
            //Create a token from a cancel source object
            connectCancelToken = connectCancel.Token;
            //Start the connection task
            Task socketConnectTask = socketClient.ConnectAsync(new Uri("ws://" + networkAddress + ":" + networkPort + "/"), connectCancelToken);
        }

        //Cancel a socket connection attempt
        public void cancelConnect()
        {
            connectCancel.Cancel();
        }

        public WebSocketState getClientState()
        {
            if (socketClient != null)
            {
                return socketClient.State;
            }
            else
            {
                return WebSocketState.None;
            }
            
        }

        public void disconnect()
        {
            socketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "User requested disconnect", System.Threading.CancellationToken.None);
        }
    }
}
