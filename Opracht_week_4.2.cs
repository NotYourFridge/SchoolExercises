using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Xunit.Abstractions;

namespace MyLinqVersions
{

    static class MijnLINQExtensies
    {

        public static bool MyAny<T>(this IEnumerable<T> source, Func<T, bool> predicaat)
        {
            // foreach (var item in me)
            // {
            //     if (predicaat(item))
            //     {
            //         return true;
            //     }
            // }
            // return false;

            return !source.All(item => !predicaat(item));

            /*
            In deze implementatie wordt de All-methode gebruikt om te controleren of er geen elementen zijn die niet aan de voorwaarde voldoen (door de negatie !predicaat(item) te gebruiken). 
            Als All aangeeft dat er geen dergelijke elementen zijn, betekent dit dat alle elementen aan de voorwaarde voldoen. 
            We negeren deze waarheidswaarde met ! om te bepalen of er ten minste één element is dat aan de voorwaarde voldoet, en dit resultaat wordt geretourneerd.
            Met deze MyAny-methode kun je controleren of er ten minste één element in de reeks is dat aan de opgegeven voorwaarde voldoet, net als de standaard Any-methode van LINQ.
             */
        }


        public static T MySingle<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            // T foundItem = default!;
            // int counter = 0;
            // foreach (var item in source)
            // {
            //     if (predicate(item))
            //     {
            //         foundItem = item;
            //         counter++;
            //     }
            // }
            // if (counter > 1)
            // {
            //     throw new InvalidOperationException("Er zijn meer dan 1 items gevonden met dezelfde voorwaarde");
            // }
            // else if (counter == 0)
            // {
            //     throw new InvalidOperationException("Er is geen item gevonden die voldoet aan de voorwaarde");
            // }

            // return foundItem;
            T resultaat = source.First(predicate);
            int counter = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    counter++;
                }
            }

            if (counter > 1)
            {
                throw new InvalidOperationException("Er zijn meer dan 1 items gevonden met dezelfde voorwaarde");
            }
            else if (counter == 0)
            {
                throw new InvalidOperationException("Geen items die zich voldoen aan de voorwaarde");
            }

            return resultaat;
        }

        public static IEnumerable<T> MyOfType<T>(this IEnumerable<T> source)
        {



            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Where(item => item is T);


        }

        public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int amountOfSkips)
        {
            var genummerdeItems = source.Select((item, index) => new { Index = index, Item = item })
            .SkipWhile((item, index) => index < amountOfSkips)
            .Select(item => item.Item);

            return genummerdeItems;

        }

        public static double MyAverage(this IEnumerable<int> source)
        {
            int counter = 0;
            var sum = source.Aggregate(0, (accumulator, current) => accumulator + current);

            foreach(var number in source){
                counter++;
            }   
            return (double)sum / counter;
        }

    }

    class Program
    {

        // public static void Main()
        // {

        //     List<object> mixedList = new List<object>
        // {
        //     1,
        //     "Hello",
        //     3.14,
        //     "World",
        //     42,
        // };

        //     // Gebruik Where met is om alleen de string-elementen te selecteren
        //     IEnumerable<object> stringsOnly = mixedList.OfType<string>();

        //     foreach (object item in stringsOnly)
        //     {
        //         // Cast naar string om toegang te krijgen tot string-specifieke functionaliteit
        //         string str = (string)item;
        //         Console.WriteLine(str);
        //     }

        //     List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        //     // Test 1: Enkelvoudig item vinden
        //     int result1 = numbers.MySingle(x => x == 3);
        //     Console.WriteLine(result1); // Moet 3 afdrukken

        //     // Test 2: Geen item gevonden
        //     try
        //     {
        //         int result2 = numbers.MySingle(x => x == 10);
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         Console.WriteLine(ex.Message); // Moet "Er zijn geen items gevonden die voldoen aan de voorwaarde" afdrukken
        //     }

        //     // Test 3: Meerdere overeenkomende items
        //     try
        //     {
        //         int result3 = numbers.MySingle(x => x % 2 == 0);
        //     }
        //     catch (InvalidOperationException ex)
        //     {
        //         Console.WriteLine(ex.Message); // Moet "Er zijn meer dan 1 items gevonden met dezelfde voorwaarde" afdrukken
        //     }


        //     List<int> number = new List<int> { 10, 20, 30, 40, 50 };

        //     double average = number.MyAverage();

        //     Console.WriteLine($"Gemiddelde: {average}");
        // }

    }
}


// EXTENSIE METHODE voor MySingle
// T resultaat = default!;
// bool gevonden = false;

// foreach (var item in source)
// {

//     if (predicate(item))
//     {
//         if (gevonden)
//         {
//             throw new InvalidOperationException("meer dan 1 element voldoet aan de voorwaarde");
//         }
//         resultaat = item;
//         gevonden = true;
//     }

// }

// if(!gevonden){
//     throw new InvalidOperationException("niks gevonden");
// }

// return resultaat;




// List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// // Test met een geldige voorwaarde (één overeenkomend item)
// try
// {
//     int result = numbers.MySingle(x => x == 3);
//     Console.WriteLine("Resultaat: " + result); // Moet 3 weergeven
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine("Fout: " + ex.Message);
// }

// // Test met geen overeenkomende items
// try
// {
//     int result = numbers.MySingle(x => x == 10);
//     Console.WriteLine("Resultaat: " + result); // Moet een fout genereren
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine("Fout: " + ex.Message); // Moet "Er is geen item gevonden die voldoet aan de voorwaarde" weergeven
// }

// // Test met meerdere overeenkomende items
// try
// {
//     int result = numbers.MySingle(x => x % 2 == 0);
//     Console.WriteLine("Resultaat: " + result); // Moet een fout genereren
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine("Fout: " + ex.Message); // Moet "Er zijn meer dan 1 items gevonden met dezelfde voorwaarde" weergeven
// }