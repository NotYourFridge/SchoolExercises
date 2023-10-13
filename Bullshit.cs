using System.Diagnostics.Tracing;
using System.Runtime.Versioning;

namespace Bull{


class Gamer{

public static async Task pakDrank(int lopenSec){

System.Console.WriteLine("Start Lopen naar de koelkast");

await Task.Delay(lopenSec);

System.Console.WriteLine("Drank is uit de koelkast gepakt");

}

}


class Game{

public static async Task startSpelOp(int ladenSec){

System.Console.WriteLine("Spel is opgestart: Wachten op server");

await Task.Delay(ladenSec);

System.Console.WriteLine("Spel is gereed. Genieten maar!");

}

}

class Program{

// public static async Task Main(string []args){

// System.Console.WriteLine("Begin Main....");

// var startSpelOpTaak = Game.startSpelOp(5000);

// var gamerPaktDrankTaak = Gamer.pakDrank(3000);

// await startSpelOpTaak;

// await gamerPaktDrankTaak;

// await Game.startSpelOp(5000);

// await Gamer.pakDrank(8000);



// System.Console.WriteLine("Einde Main");

// }


}



}