using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Pretpark
{
    class Program
    {
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
            socket.Send(System.Text.Encoding.ASCII.GetBytes("HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n" + "<html><body><a href = 'https://nl.wikipedia.org/wiki/Den_Haag'>Welkom bij de website van Pretpark Den Haag!</a></body></html>"));
            socket.Close();
        }
    }
}