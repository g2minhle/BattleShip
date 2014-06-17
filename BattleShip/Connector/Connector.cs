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
        Queue send;
        protected Socket socket;
        protected StreamReader reader;
        protected StreamWriter writer;
        protected string password;
        public Queue Q;
        protected Thread thrgetinfo;
        protected Thread thrsendtinfo;
        protected void Get()
        {
            while (true)
            {
                string info = reader.ReadLine();
                if (info != "") Q.Enqueue((object)info);
            }
        }
        protected void StartGetInfo()
        {
            thrgetinfo = new Thread(Get);
            thrgetinfo.IsBackground = true;
            thrgetinfo.Start();
        }
        public string GetInfo()
        {
            if (Q.Count > 0)
            {
                return (string)Q.Dequeue();
            }
            return "";
        }

        protected void SetWriterReader(Socket sk)
        {
            NetworkStream ns = new NetworkStream(sk);
            reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
            send = new Queue();
            thrsendtinfo = new Thread(Sending);
            thrsendtinfo.IsBackground = true;
            thrsendtinfo.Start();
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
        private void Sending()
        {
            while (true)
            {
                if (send.Count != 0)
                {
                    writer.WriteLine((string )send.Dequeue());
                    writer.Flush();
                }
            }
        }
        public void Send(string s)
        {
            send.Enqueue((object)s);
        }
    }
    public class Server : MainConnector
    {
        public Server(string pass)
        {
            Q = new Queue();
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
            DisposeThread(ref thrsendtinfo);
        }

        Thread thrlisten;
        public delegate void DoneListenHandel();
        public event DoneListenHandel DoneListen;
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
                    if (CheckPass())
                    {
                        Q.Clear();
                        DoneListen();
                        return;
                    }
                    Q.Clear();
                    EmptyWriterReader();
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

        bool CheckPass()
        {
            while (Q.Count == 0) { }
            if (GetInfo() == password)
            {
                Send("right");
                return true;
            }
            Send("wrong");
            Q.Clear();
            return false;
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
                    while (Q.Count == 0) Send(password);
                    if (string.Compare(GetInfo(), "right", true) == 0)
                        Connected();
                    else
                        CannotConnected();
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
            DisposeThread(ref thrsendtinfo);
        }
        public Client(string pass, string ipaddress)
        {
            Q = new Queue();
            password = pass;
            this.ipaddress = ipaddress;
            StartConnect();
        }
    }
}
