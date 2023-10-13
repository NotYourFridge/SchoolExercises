using System.IO.Pipes;
using PlayA;

namespace PlayB{

class Something{
        public int valueA{get;set;}
        public int valueB{get;set;}
        

        public Something(int a, int b) => (valueA, valueB) = (a, b);


}



class Program{

// public static void Main(string[] args){
// Something something = new Something(15,5);
// System.Console.WriteLine("value A = {0} and value B = {1}", something.valueA, something.valueB);

// int x = something.valueA;

// int y = something.valueB;

// Modifier.Swap(ref x, ref y);

// System.Console.WriteLine("value A = {0} and value B = {1} (they are swapped btw)", x, y);

// S s = new S();

// Modifier.Modify(s);
// System.Console.WriteLine(s.num);

// Modifier.Modify2(ref s);
// System.Console.WriteLine(s.num);

// int number = 1;

// number = 2;

// System.Console.WriteLine(number);


// }

}


struct S {

public int num;

}

class Modifier{
    public static void Modify(S s){
        s.num = 10;
    }

//using ref because the int num is a value type, which can't be passed by reference because it sends a copy of itself...
    public static void Modify2(ref S s){
        s.num = 10;
    }

   public static void Swap<T>(ref T x, ref T y){
        T temperaryStored = x;
        x = y;
        y = temperaryStored;
    }

}




}