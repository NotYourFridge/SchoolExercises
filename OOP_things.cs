using System.Globalization;
using System.IO.Pipes;
using System.Reflection;

namespace OOP{


class A{

int numberA;

public int numbA{
    get{return numberA;}
    set{
        if(value == 0){
            System.Console.WriteLine("the number cannot be zero man...");
            numberA = value + 1;
        }else{
            numberA = value;
        }
    }
    }

}

class B{

int numberB;

   public int myProp{
    get => numberB;
    set => numberB = value + 1;
   }

}

class Program{

// public static void Main(string[] args){
//     B b = new B(){
//         myProp = 1
//     };


//     System.Console.WriteLine(b.myProp);

//     A a = new A(){
//        numbA = 0
//     };

//     System.Console.WriteLine(a.numbA);

// }

}


}