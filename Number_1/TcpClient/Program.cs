using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        Console.Write("Введите ваше имя: ");
        string? name = Console.ReadLine();

        using (TcpClient client = new TcpClient("127.0.0.1", 3361))
        using (NetworkStream stream = client.GetStream())
        {
            byte[] data = Encoding.UTF8.GetBytes(name);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytes);

            Console.WriteLine(response);
        }
    }
}
