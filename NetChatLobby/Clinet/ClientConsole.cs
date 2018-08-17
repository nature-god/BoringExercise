using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main(string[] args)
    {
        Console.WriteLine("Client Running ...");
        TcpClient Client;
        ConsoleKey Key;
        const int BufferSize = 8192;
        try
        {
            Client = new TcpClient();
            Client.Connect("localhost",8500);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        Console.WriteLine("Server Connected!{0}-->{1}",Client.Client.LocalEndPoint,Client.Client.RemoteEndPoint);
        NetworkStream streamToServer = Client.GetStream();
        Console.WriteLine("Menu: S -- Send, X -- Exit");

        do
        {
            Key = Console.ReadKey(true).Key;
            if(Key == ConsoleKey.S)
            {
                Console.WriteLine("Input the Message: ");
                string msg = Console.ReadLine();
                byte[] buffer = Encoding.Unicode.GetBytes(msg);
                try
                {
                    lock(streamToServer)
                    {
                        streamToServer.Write(buffer,0,buffer.Length);
                    }
                    Console.WriteLine("Sent:{0}",msg);
                    int bytesRead;
                    buffer = new byte[BufferSize];
                    lock(streamToServer)
                    {
                        bytesRead = streamToServer.Read(buffer,0,BufferSize);
                    } 
                    msg = Encoding.Unicode.GetString(buffer,0,bytesRead);
                    Console.WriteLine("Received: {0}",msg);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }while(Key != ConsoleKey.X);
        streamToServer.Dispose();
        Client.Close();
        Console.WriteLine("\n\n输入\"Q\"键退出.");
        do
        {
            Key =  Console.ReadKey(true).Key;
        }while(Key != ConsoleKey.Q);
    }
}