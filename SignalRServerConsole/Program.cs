using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRServerConsole
{
    class Program
    {
        private static IDisposable _signalR;
        private static BindingList<ClientItem> _clients = new BindingList<ClientItem>();
        private static BindingList<string> _groups = new BindingList<string>();
        static void Main(string[] args)
        {
            SimpleHub.ClientConnected += SimpleHub_ClientConnected;
            SimpleHub.ClientDisconnected += SimpleHub_ClientDisconnected;
            SimpleHub.ClientNameChanged += SimpleHub_ClientNameChanged;
            SimpleHub.ClientJoinedToGroup += SimpleHub_ClientJoinedToGroup;
            SimpleHub.ClientLeftGroup += SimpleHub_ClientLeftGroup;
            SimpleHub.MessageReceived += SimpleHub_MessageReceived;
            StartSignalRServer();
            ThreadStart threadStart = new ThreadStart(StartSocketServer);
            Thread socketThread = new Thread(threadStart);
            socketThread.Start();
        }

        private static void StartSocketServer()
        {
            // Establish the local endpoint  
            // for the socket. Dns.GetHostName 
            // returns the name of the host  
            // running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 60000);

            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {

                // Using Bind() method we associate a 
                // network address to the Server Socket 
                // All client that will connect to this  
                // Server Socket must know this network 
                // Address 
                listener.Bind(localEndPoint);

                // Using Listen() method we create  
                // the Client list that will want 
                // to connect to Server 
                listener.Listen(10);
                Console.WriteLine("Socket Server Started.");
                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    // Suspend while waiting for 
                    // incoming connection Using  
                    // Accept() method the server  
                    // will accept connection of client 
                    Socket clientSocket = listener.Accept();

                    // Data buffer 
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);
                        if (numByte == 0)
                            break;

                        data += Encoding.ASCII.GetString(bytes,
                                                   0, numByte);


                    }


                    //   byte[] message = Encoding.ASCII.GetBytes("Test Server");

                    var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();
                    Console.WriteLine($"Data Received:{data}");
                    hubContext.Clients.All.addMessage("SERVER", data);
                    Console.WriteLine($"Socket Server is listning on localhost");
                    // Send a message to Client  
                    // using Send() method 
                    // clientSocket.Send(message);

                    // Close client Socket using the 
                    // Close() method. After closing, 
                    // we can use the closed Socket  
                    // for a new Client Connection 
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SimpleHub_ClientConnected(string clientId)
        {
            _clients.Add(new ClientItem() { Id = clientId, Name = clientId });

            Console.WriteLine($"Client connected:{clientId}");
        }

        private static void SimpleHub_ClientDisconnected(string clientId)
        {
            var client = _clients.FirstOrDefault(x => x.Id == clientId);
            if (client != null)
                _clients.Remove(client);

            Console.WriteLine($"Client disconnected:{clientId}");
        }

        private static void SimpleHub_ClientNameChanged(string clientId, string newName)
        {
            var client = _clients.FirstOrDefault(x => x.Id == clientId);
            if (client != null)
                client.Name = newName;

            Console.WriteLine($"Client name changed. Id:{clientId}, Name:{newName}");
        }

        private static void SimpleHub_ClientJoinedToGroup(string clientId, string groupName)
        {
            var group = _groups.FirstOrDefault(x => x == groupName);
            if (group == null)
                _groups.Add(groupName);

            Console.WriteLine($"Client joined to group. Id:{clientId}, Group:{groupName}");
        }

        private static void SimpleHub_ClientLeftGroup(string clientId, string groupName)
        {
            Console.WriteLine($"Client left group. Id:{clientId}, Group:{groupName}");
        }

        private static void SimpleHub_MessageReceived(string senderClientId, string message)
        {
           
        }

        private static void StartSignalRServer()
        {
            _signalR = WebApp.Start<Startup>(ConfigurationManager.AppSettings["signalRUrl"].ToString());

            Console.WriteLine($"SignalR Server started at:{ConfigurationManager.AppSettings["signalRUrl"].ToString()}");
        }
    }
}
