using System.Collections.Specialized;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Pretpark
{
    class Program
    {

        private static int counter = 0;

        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), 5000);
            server.Start();


            while (true)
            {

                using Socket connectie = server.AcceptSocket();
                HandleHTTPRequests(connectie);

            }
            /*
            De AcceptSocket()-methode wordt meestal gebruikt in het kader van een servertoepassing die wacht op inkomende verbindingen van clients.
            Het accepteert een inkomende verbinding en retourneert een socketobject dat kan worden gebruikt om te communiceren met de verbonden client.
            */


        }

        static void HandleHTTPRequests(Socket socket)
        {
            /*
            new NetworkStream(connectie): Dit is een constructoraanroep die een NetworkStream-object initialiseert met de socketverbinding connectie als parameter.
            NetworkStream is een klasse die in C# wordt gebruikt om gegevens te verzenden en ontvangen via een netwerksocket.
            Door de socketverbinding om te zetten in een stream, kun je gemakkelijker gegevens lezen en schrijven met behulp van standaardstroombewerkingen.
            */
            using Stream request = new NetworkStream(socket);
            /*
            Stap 1: Een StreamReader-object creëren.
            Met de code using StreamReader requestLezer = new StreamReader(request); maak je een StreamReader met de naam requestLezer.    

            Stap 2: Gegevens lezen. De StreamReader (requestLezer) wordt gebruikt om gegevens van een stroom (request) te lezen. 
            In dit geval, wordt de stroom meestal gebruikt om gegevens van een netwerkverbinding te lezen, zoals tekstberichten die door een client zijn verzonden.

            Stap 3: Interpreteren van gegevens. De StreamReader interpreteert de gelezen gegevens als tekst, waardoor je ze in je programma kunt begrijpen en verwerken. 
            Dit kan handig zijn als je bijvoorbeeld berichten van een client wilt begrijpen en erop wilt reageren in je servertoepassing.*/
            using StreamReader requestLezer = new StreamReader(request);


            string[]? regel1 = requestLezer.ReadLine()?.Split(" ");
            if (regel1 == null) return;
            (string methode, string url, string httpversie) = (regel1[0], regel1[1], regel1[2]);
            string? regel = requestLezer.ReadLine();
            int contentLength = 0;
            while (!string.IsNullOrEmpty(regel) && !requestLezer.EndOfStream)
            {
                string[] stukjes = regel.Split(":");
                (string header, string waarde) = (stukjes[0], stukjes[1]);
                if (header.ToLower() == "content-length")
                    contentLength = int.Parse(waarde);
                regel = requestLezer.ReadLine();
            }
            if (contentLength > 0)
            {
                char[] bytes = new char[(int)contentLength];
                requestLezer.Read(bytes, 0, (int)contentLength);
            }

            if (regel1.Length >= 3)
            {

                if (methode == "GET" && url == "/contact")
                {

                    string response = "HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n";
                    response += "<html><body><a href='/'>Home</a></body></html>";

                    byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(response);
                    socket.Send(responseBytes);
                    socket.Close();
                }
                else if (methode == "GET" && url == "/teller")
                {
                    string response = "HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n";
                    response += $"<html><body>Counter: {TellerTelOp()}</body></html>";

                    byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(response);
                    socket.Send(responseBytes);
                    socket.Close();
                }
                else if (methode == "GET" && url.StartsWith("/add"))
                {
                    string response = "HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n";
                    response += $"<html><body>Som: {ParseQueryString(url)}</body></html>";

                    byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(response);
                    socket.Send(responseBytes);
                    socket.Close();
                }
                else if (methode == "GET" && url.StartsWith("/mijnteller"))
                {
                    string queryString = "?count=1";
                    if (url.Contains("?count="))
                    {
                        int startIndex = url.IndexOf("?count=") + 7;
                        int endIndex = url.IndexOf("&", startIndex);
                        if (endIndex == -1)
                        {
                    
                            endIndex = url.Length;
                        }
                        queryString = url.Substring(startIndex, endIndex - startIndex);
                    }

                    if (int.TryParse(queryString, out int count))
                    {
                        
                        string response = "HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n";
                        response += $"<html><body>De teller staat op {count}, <a href='/mijnteller?count={count + 1}'>klik hier om te verhogen</a></body></html>";

                        byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(response);
                        socket.Send(responseBytes);
                    }
                    
                    socket.Close();
                }
                else
                {
                    socket.Send(System.Text.Encoding.ASCII.GetBytes("HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n" + "<html><body><a href = 'https://nl.wikipedia.org/wiki/Den_Haag'>Welkom bij de website van Pretpark Den Haag!</a></body></html>"));
                    socket.Send(System.Text.Encoding.ASCII.GetBytes("<html><body><br><a href='/contact'>Contact</a></body></html>"));
                    socket.Close();
                }

            }

        }

        static int TellerTelOp()
        {
            return counter++;
        }

        static int ParseQueryString(string request)
        {
            int a = 0, b = 0;
            string[] queryParts = request.Split('?');
            if (queryParts.Length == 2)
            {
                string queryString = queryParts[1];
                string[] parameters = queryString.Split('&');

                foreach (string parameter in parameters)
                {
                    string[] parts = parameter.Split('=');
                    if (parts.Length == 2)
                    {
                        if (parts[0] == "a")
                        {
                            int.TryParse(parts[1], out a);
                        }
                        else if (parts[0] == "b")
                        {
                            int.TryParse(parts[1], out b);
                        }
                    }
                }
            }
            return a + b;
        }

        static int verhoog(int number)
        {
            return number++;
        }

    }
}