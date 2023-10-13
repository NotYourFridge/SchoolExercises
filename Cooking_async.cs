namespace Cooking2{


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
    // public static async Task<Rijst> Koken()
    // {
    //     await Task.Delay(20 * 1000);
    //     return new Rijst();
    // }

    // public static async Task<GesnedenGroente> Snijden()
    // {
    //     await Task.Delay(5 * 1000);
    //     return new GesnedenGroente();
    // }

    // public static async Task<GewokteGroente> Wokken(GesnedenGroente gesnedenGroente)
    // {
    //     await Task.Delay(5 * 1000);
    //     return new GewokteGroente(gesnedenGroente);
    // }

    // public static async Task Main(string[] args)
    // {
    //     Task<Rijst> taskRijst = Koken();
    //     GesnedenGroente gesnedenGroente = await Snijden();
    //     GewokteGroente gewokteGroente = await Wokken(gesnedenGroente);
    //     Rijst rijst = await taskRijst;
    //     Maaltijd maaltijd = new Maaltijd(rijst, gewokteGroente);
    // }
}


}