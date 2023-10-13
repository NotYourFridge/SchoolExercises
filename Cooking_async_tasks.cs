namespace Cooking3{


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

    //     Task task = Task.Run(() => { for (long i = 0; i < 2000000000; i++) ; });
    //     await task;
    //     return new Rijst();
    // }

    // public static async Task<GesnedenGroente> Snijden()
    // {
    //     Task task = Task.Run(() => { for (long i = 0; i < 1000000000; i++) ; });
    //     await task;
    //     return new GesnedenGroente();
    // }

    // public static async Task<GewokteGroente> Wokken(GesnedenGroente gesnedenGroente)
    // {
    //     Task task = Task.Run(() => { for (long i = 0; i < 1000000000; i++) ; });
    //     await task;
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