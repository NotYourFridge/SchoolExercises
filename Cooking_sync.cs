namespace Cooking{


class GesnedenGroente
{
    public GesnedenGroente()
    {
        Console.WriteLine("GesnedenGroente klaar");
    }
}

class GewokteGroente
{
    public GesnedenGroente GesnedenGroente;

    public GewokteGroente(GesnedenGroente gesnedenGroente)
    {
        this.GesnedenGroente = gesnedenGroente; ;
        Console.WriteLine("GewokteGroente klaar");
    }
}

class Rijst
{
    public Rijst()
    {
        Console.WriteLine("Rijst klaar");
    }
}

class Maaltijd
{
    public Rijst Rijst;
    public GewokteGroente GewokteGroente;

    public Maaltijd(Rijst rijst, GewokteGroente gewokteGroente)
    {
        this.Rijst = rijst;
        this.GewokteGroente = gewokteGroente;
        Console.WriteLine("Maaltijd klaar");
    }
}

class Program
{
    // public static Rijst Koken()
    // {
    //     Thread.Sleep(20 * 1000);
    //     return new Rijst();
    // }

    // public static GesnedenGroente Snijden()
    // {
    //     Thread.Sleep(5 * 1000);
    //     return new GesnedenGroente();
    // }

    // public static GewokteGroente Wokken(GesnedenGroente gesnedenGroente)
    // {
    //     Thread.Sleep(5 * 1000);
    //     return new GewokteGroente(gesnedenGroente);
    // }

    // public static void Main(string[] args)
    // {
    //     Rijst rijst = Koken();
    //     GesnedenGroente gesnedenGroente = Snijden();
    //     GewokteGroente gewokteGroente = Wokken(gesnedenGroente);
    //     Maaltijd maaltijd = new Maaltijd(rijst, gewokteGroente);
    // }
}


}