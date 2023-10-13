namespace PlayA{

class Program{


// public static void Main(string [] args){

// DateTime dt = DateTime.Now; //--> geeft de daadwerkelijk datum en tijd weer
// string formatted_date = string.Format("Datum {0:yyyy MMMM dddd HH : mm : ss}", dt);
// Console.WriteLine(formatted_date);

// A a = new A();

// a.Method();

// B b = new B();
// // A b = new B();

// b.Method("empty string");

// }





/*
3 manieren:

1. Overloaden
2. Overriden
3. Hiden

1. Bij overloaden zorg je ervoor dat de methods in de derived class params heeft zodat je onderscheid maakt tussen de base en derived method.

2. Overriden gebruik je bij polymorphism. De base method is dan de virtual method en de derived method is dan de override method.

3. Bij hiden gebruik je de new keyword bij de derived method.

*/



}



class A{

public void Method(){
    System.Console.WriteLine("Bomboclat");
}


}


class B : A{


        public void Method(string input)
        {
           System.Console.WriteLine("yoyo this input = {0}", input);
        }


    }


}