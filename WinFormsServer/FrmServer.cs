using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.AspNet.SignalR;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WinFormsServer
{
    public partial class FrmServer : Form
    {
        private IDisposable _signalR;
        private BindingList<ClientItem> _clients = new BindingList<ClientItem>();
        private BindingList<string> _groups = new BindingList<string>();

        public FrmServer()
        {
            InitializeComponent();

            bindListsToControls();

            //Register to static hub events
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
           
            btnSocketServer.Enabled = false;
        }

        private void bindListsToControls()
        {
            //Clients list
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";
            cmbClients.DataSource = _clients;

            //Groups list
            cmbGroups.DataSource = _groups;
        }

        private void SimpleHub_ClientConnected(string clientId)
        {
            //Add client to our clients list
            this.BeginInvoke(new Action(() => _clients.Add(new ClientItem() { Id = clientId, Name = clientId })));

            writeToLog($"Client connected:{clientId}");
        }

        private void SimpleHub_ClientDisconnected(string clientId)
        {
            //Remove client from the list
            this.BeginInvoke(new Action(() =>
            {
                var client = _clients.FirstOrDefault(x => x.Id == clientId);
                if (client != null)
                    _clients.Remove(client);
            }));

            writeToLog($"Client disconnected:{clientId}");
        }

        private void SimpleHub_ClientNameChanged(string clientId, string newName)
        {
            //Update the client's name if it exists
            this.BeginInvoke(new Action(() =>
            {
                var client = _clients.FirstOrDefault(x => x.Id == clientId);
                if (client != null)
                    client.Name = newName;
            }));

            writeToLog($"Client name changed. Id:{clientId}, Name:{newName}");
        }

        private void SimpleHub_ClientJoinedToGroup(string clientId, string groupName)
        {
            //Only add the groups name to our groups list
            this.BeginInvoke(new Action(() =>
            {
                var group = _groups.FirstOrDefault(x => x == groupName);
                if (group == null)
                    _groups.Add(groupName);
            }));

            writeToLog($"Client joined to group. Id:{clientId}, Group:{groupName}");
        }

        private void SimpleHub_ClientLeftGroup(string clientId, string groupName)
        {
            writeToLog($"Client left group. Id:{clientId}, Group:{groupName}");
        }

        private void SimpleHub_MessageReceived(string senderClientId, string message)
        {
            //One of the clients sent a message, log it
            this.BeginInvoke(new Action(() =>
            {
                string clientName = _clients.FirstOrDefault(x => x.Id == senderClientId)?.Name;

                writeToLog($"{clientName}:{message}");
            }));
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            txtLog.Clear();

            try
            {
                //Start SignalR server with the give URL address
                //Final server address will be "URL/signalr"
                //Startup.Configuration is called automatically
                StartSignalRServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartSignalRServer()
        {
            _signalR = WebApp.Start<Startup>(txtUrl.Text);

            btnStartServer.Enabled = false;
            txtUrl.Enabled = false;
            btnStop.Enabled = true;
            grpBroadcast.Enabled = true;

            writeToLog($"SignalR Server started at:{txtUrl.Text}");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _clients.Clear();
            _groups.Clear();

            SimpleHub.ClearState();

            if (_signalR != null)
            {
                _signalR.Dispose();
                _signalR = null;

                btnStop.Enabled = false;
                btnStartServer.Enabled = true;
                txtUrl.Enabled = true;
                grpBroadcast.Enabled = false;

                writeToLog("Server stopped.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimpleHub>();

            if (rdToAll.Checked)
            {
                hubContext.Clients.All.addMessage("SERVER", txtMessage.Text);
            }
            else if (rdToGroup.Checked)
            {
                hubContext.Clients.Group(cmbGroups.Text).addMessage("SERVER", txtMessage.Text);
            }
            else if (rdToClient.Checked)
            {
                hubContext.Clients.Client((string)cmbClients.SelectedValue).addMessage("SERVER", txtMessage.Text);
            }
        }

        private void writeToLog(string log)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new Action(() => txtLog.AppendText(log + Environment.NewLine)));
            else
                txtLog.AppendText(log + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartSocketServer();
        }

        private void StartSocketServer()
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
                writeToLog("Socket Server Started.");
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
                    writeToLog($"Data Received:{data}");
                    hubContext.Clients.All.addMessage("SERVER", data);
                    writeToLog($"Socket Server is listning on localhost");
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
    }
}
