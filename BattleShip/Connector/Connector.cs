using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
namespace Connector
{
    public class MainConnector
    {
        public MainConnector() { }
        public static bool RightIP(string ip)
        {
            try
            {
                IPHostEntry iphostentry = Dns.GetHostEntry(ip);
                return true;
            }
            catch { return false; }
        }
        protected Socket socket;
        protected StreamReader reader;
        protected StreamWriter writer;
        protected string password;
        protected Thread thrgetinfo;

        protected void Get()
        {
            while (true)
            {
                string info = reader.ReadLine();
                if (info != "")
                    GotInfo(info);
            }
        }
        public delegate void GotInfoHandel(string info);
        public event GotInfoHandel GotInfo;
        protected void StartGetInfo()
        {
            thrgetinfo = new Thread(Get);
            thrgetinfo.IsBackground = true;
            thrgetinfo.Start();
        }
        protected void SetWriterReader(Socket sk)
        {
            NetworkStream ns = new NetworkStream(sk);
            reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
        }
        protected void EmptyWriterReader()
        {
            reader = null;
            writer = null;
        }
        protected void DisposeThread(ref Thread thr)
        {
            if (thr.IsAlive == true)
            { thr.Abort(); }
        }
        public void Send(string s)
        {
            //writer.WriteLine((string)send.Dequeue());
            writer.WriteLine(s);
            writer.Flush();
            //send.Enqueue((object)s);
        }
    }
    public class Server : MainConnector
    {
        public Server(string pass)
        {
            password = pass;
            IPEndPoint localendpoint = new IPEndPoint(IPAddress.Any, 5000);
            socket = new Socket(localendpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(localendpoint);
                socket.Listen(1);
            }
            catch (SocketException ex)
            {
                #region Failed to start server
                MessageBox.Show("Failed to start server" + ex.Message, "Failed to start server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (socket != null)
                {
                    socket.Disconnect(false);
                    socket.Close();
                }
                #endregion
            }
            StartListen();

        }

        void Dispose()
        {
            if (socket != null)
            {
                socket.Disconnect(false);
                socket.Close();
            }
            DisposeThread(ref thrgetinfo);
            DisposeThread(ref thrlisten);
            EmptyWriterReader();
        }

        Thread thrlisten;
        public delegate void DoneListenHandel();
        public event DoneListenHandel DoneListen;
        void Server_GotInfo(string info)
        {
            if (info == password)
            {
                Send("r");
                DoneListen();
            }
            else
            {
                Send("w");
                EmptyWriterReader();
                StartListen();
            }
        }
        void Listen()
        {
            try
            {
                #region Wating to connect and then connect
                while (true)
                {
                    Socket clientsocket = socket.Accept();
                    SetWriterReader(clientsocket);
                    StartGetInfo();
                    GotInfo += new GotInfoHandel(Server_GotInfo);
                }
                #endregion
            }
            catch (SocketException ex)
            {
                #region Can not accept connection
                MessageBox.Show("Server could not accept connection" + ex.Message
                    , "Server could not accept connection:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endregion
            }
        }


        void StartListen()
        {
            thrlisten = new Thread(Listen);
            thrlisten.IsBackground = true;
            thrlisten.Start();
        }


    }
    public class Client : MainConnector
    {
        string ipaddress;
        Thread thrconnect;
        public delegate void ConnectedHandel();
        public event ConnectedHandel Connected;
        public delegate void CannotConnectedHandel();
        public event CannotConnectedHandel CannotConnected;

        void Connect()
        {
            try
            {
                IPHostEntry hostentry = Dns.GetHostEntry(ipaddress);
                IPAddress ip = hostentry.AddressList[0];
                IPEndPoint serverenpoint = new IPEndPoint(ip, 5000);
                socket = new Socket(serverenpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Connect(serverenpoint);
                    SetWriterReader(socket);
                    StartGetInfo();
                    Send(password);
                    GotInfo += new GotInfoHandel(Client_GotInfo);
                }
                catch (SocketException)
                {
                    if (socket != null)
                        socket.Close();
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Could not resolve server DNS name:" + ex.Message
                    , "Could not resolve server DNS name"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        void Client_GotInfo(string info)
        {
            if (info == "r")
                Connected();
            else
                CannotConnected();
        }
        void StartConnect()
        {
            thrconnect = new Thread(Connect);
            thrconnect.IsBackground = true;
            thrconnect.Start();
        }
        void Dispose()
        {
            if (socket != null)
            {
                socket.Disconnect(false);
                socket.Close();
            }
            DisposeThread(ref thrgetinfo);
            DisposeThread(ref thrconnect);
        }
        public Client(string pass, string ipaddress)
        {
            password = pass;
            this.ipaddress = ipaddress;
            StartConnect();
        }
    }
}
