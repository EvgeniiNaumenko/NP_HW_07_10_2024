using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    //static void Main(string[] args)
    //{
    //    TcpListener server = null;
    //    try
    //    {
    //        int port = 8000;
    //        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
    //        server = new TcpListener(localAddr, port);
    //        server.Start();

    //        Console.WriteLine("Сервер запущен. Ожидание подключений...");

    //        while (true)
    //        {
    //            TcpClient client = server.AcceptTcpClient();
    //            Console.WriteLine("Клиент подключился.");
    //            NetworkStream stream = client.GetStream();

    //            byte[] buffer = new byte[256];
    //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
    //            string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();


    //            string response;
    //            if (request.Equals("time", StringComparison.OrdinalIgnoreCase))
    //            {
    //                response = DateTime.Now.ToString("HH:mm:ss");
    //            }
    //            else if (request.Equals("date", StringComparison.OrdinalIgnoreCase))
    //            {
    //                response = DateTime.Now.ToString("yyyy-MM-dd");
    //            }
    //            else
    //            {
    //                response = "Некорректный запрос";
    //            }

    //            byte[] responseData = Encoding.UTF8.GetBytes(response);
    //            stream.Write(responseData, 0, responseData.Length);

    //            client.Close();
    //            Console.WriteLine("Соединение закрыто.");
    //        }
    //    }
    //    catch (SocketException e)
    //    {
    //        Console.WriteLine($"Ошибка сокета: {e.Message}");
    //    }
    //    finally
    //    {
    //        if (server != null)
    //        {
    //            server.Stop();
    //        }
    //    }

    //}

    // Доп Задание 1
    static void Main(string[] args)
    {
        TcpListener server = null;
        try
        {
            int port = 8000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, port);
            server.Start();

            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Клиент подключился.");
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                string response;

                if (double.TryParse(request, out double number))
                {
                    double result = Math.Sqrt(number);
                    response = result.ToString();
                }
                else
                {
                    response = "Ошибка: Некорректное число.";
                }

                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);

                client.Close();
                Console.WriteLine("Соединение закрыто.");
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine($"Ошибка сокета: {e.Message}");
        }
        finally
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
