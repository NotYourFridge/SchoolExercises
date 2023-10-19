using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using OOP;

namespace L
{



    class Executor
    {

        int x;

        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Executor(int x, int y) => (X, Y) = (x, y);

        public static Func<int, int, int> sum = (a, b) => a + b;



        public static void Method()
        {

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);

            foreach (var numb in evenNumbers)
            {

                System.Console.WriteLine(numb);

            }
        }


        public static Func<int, string> even_or_odd = n => n % 2 == 0 ? "Even" : "Odd";


        public static Func<double, double, double> addDoubles = (a, b) => a + b;


        public static int calculation(int x, int y) => x + y;


        public static T returnType<T>(T x)
        {
            return x;
        }

        public static Func<int,int> kwadraat = (a) => {
            return a * a;
        };

        public static Func<int,int> kwadraat2 = (a) => a*a;

        public static int Method(int x) => x;


    }

    class Program
    {


        // public static void Main(string[] args)
        // {

        //     string answer = Executor.even_or_odd(1);

        //     double addition = Executor.addDoubles(1.5d, 1.2d);

        //     int addition2 = Executor.calculation(1, 3);

        //     System.Console.WriteLine(answer);

        //     System.Console.WriteLine(addition);

        //     System.Console.WriteLine(addition2);

        //     Executor.Method();

        // }


    }


}