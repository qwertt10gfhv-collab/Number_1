using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 3361);
        listener.Start();

        TcpClient client = listener.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytes = stream.Read(buffer, 0, buffer.Length);
        string name = Encoding.UTF8.GetString(buffer, 0, bytes);

        Console.WriteLine("Получено: " + name);

        string reply = "Привет, " + name + "!";
        byte[] replyData = Encoding.UTF8.GetBytes(reply);
        stream.Write(replyData, 0, replyData.Length);

        stream.Close();
        client.Close();
        listener.Stop();
    }
}