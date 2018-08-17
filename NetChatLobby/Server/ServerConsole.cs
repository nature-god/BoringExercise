using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

class Server
{
    static void Main(string[] args)
    {
        const int BufferSize = 8192;
        ConsoleKey key;

        Console.WriteLine("Server is running");
        IPAddress ip = new IPAddress(new byte[] {127,0,0,1});
        TcpListener listener = new TcpListener(ip,8500);
        listener.Start();
        Console.WriteLine("Start Listening...");
        TcpClient remoteClinet = listener.AcceptTcpClient();

        Console.WriteLine("Client Connected!{0}<--{1}",remoteClinet.Client.LocalEndPoint,remoteClinet.Client.RemoteEndPoint);

        NetworkStream streamToClient = remoteClinet.GetStream();
        do
        {
            byte[] buffer = new byte[BufferSize];
            int bytesRead;
            try
            {
                lock(streamToClient)
                {
                    bytesRead = streamToClient.Read(buffer,0,BufferSize);
                }
                if(bytesRead == 0)
                {
                    throw new Exception("读取到0字节");
                }
                Console.WriteLine("Reading data,{0} bytes ...",bytesRead);

                string msg = Encoding.Unicode.GetString(buffer,0,bytesRead);
                Console.WriteLine("Received:{0}",msg);
                //Translate to Uppergrade
                msg = msg.ToUpper();
                buffer = Encoding.Unicode.GetBytes(msg);
                lock(streamToClient)
                {
                    streamToClient.Write(buffer,0,buffer.Length);
                }
                Console.WriteLine("Sent: {0}",msg);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }while(true);
        streamToClient.Dispose();
        remoteClinet.Close();
        Console.WriteLine("\n\n输入\"Q\"键退出.");
        do
        {
            key = Console.ReadKey(true).Key;
        }while(key!=ConsoleKey.Q);
    }
}