using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    //Разработайте набор консольных приложений.

    //Первое приложение: серверное приложение, которое на запросы клиента возвращает текущее время или дату на сервере.
    //Второе приложение: клиентское приложение, запрашивающее дату или время. 

    //Пользователь с клавиатуры определяет, что нужно запросить.После отсылки даты или времени сервер разрывает соединение.
    //Клиентское приложение отображает полученные данные.


    //static void Main(string[] args)
    //{
    //    try
    //    {
    //        string server = "127.0.0.1";
    //        int port = 8000;

    //        Console.WriteLine("Введите 'time' для запроса времени или 'date' для запроса даты:");
    //        string request = Console.ReadLine()?.Trim();

    //        using (TcpClient client = new TcpClient(server, port))
    //        {
    //            NetworkStream stream = client.GetStream();

    //            byte[] requestData = Encoding.UTF8.GetBytes(request);
    //            stream.Write(requestData, 0, requestData.Length);

    //            byte[] buffer = new byte[256];
    //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
    //            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    //            Console.WriteLine($"Ответ сервера: {response}");
    //        }
    //    }
    //    catch (SocketException e)
    //    {
    //        Console.WriteLine($"Ошибка сокета: {e.Message}");
    //    }
    //}


    // Доп Задание 1
    //Создайте сервер, который принимает запрос от клиента, вычисляет квадратный корень числа,
    //отправленного клиентом, и возвращает результат.

    static void Main(string[] args)
    {
        try
        {
            string server = "127.0.0.1";
            int port = 8000;

            Console.WriteLine("Введите число для вычисления корня:");
            string request = Console.ReadLine()?.Trim();

            using (TcpClient client = new TcpClient(server, port))
            {
                NetworkStream stream = client.GetStream();

                byte[] requestData = Encoding.UTF8.GetBytes(request);
                stream.Write(requestData, 0, requestData.Length);

                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (double.TryParse(response, out double result))
                {
                    Console.WriteLine($"Корень числа {request} = {result}");
                }
                else
                {
                    throw new Exception(response);
                }
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine($"Ошибка сокета: {e.Message}");
        }
    }
}
