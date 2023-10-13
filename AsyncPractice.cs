namespace AsyncProgramming
{


    class Program
    {

        // public static void Main(string[] args)
        // {

        //     System.Console.WriteLine("Starting");

        //     var worker =  new Worker();

        //     worker.DoWork();

        //     while(!worker.IsComplete){

        //         System.Console.Write(".");
        //         Thread.Sleep(100);
        //     }

        //     System.Console.WriteLine("Done");
        //     Console.ReadKey();

        // }

    }


    class Worker{

    public bool IsComplete {get; private set;}

public async void DoWork(){

    IsComplete = false;

    System.Console.WriteLine("Doing work");

    await LongOperation();

    System.Console.WriteLine("Work completed");

    IsComplete = true;
}

private Task LongOperation(){

return Task.Factory.StartNew(() =>  {

System.Console.WriteLine("Working");
Thread.Sleep(2000);

});

}

    }


}