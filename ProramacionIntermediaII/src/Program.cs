using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProramacionIntermediaII.src
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*Tuplas*/
            List<Tuple<int, int>> TupleList = new List<Tuple<int, int>>();

            Tuple<int, int> Tuple1 = Tuple.Create(45, 9);
            var Tuple2 = Tuple.Create(17, 51);
            var Tuple3 = Tuple.Create(0, 7);
            var Tuple4 = Tuple.Create(3, 21);

            TupleList.Add(Tuple1);
            TupleList.Add(Tuple2);
            TupleList.Add(Tuple3);
            TupleList.Add(Tuple4);

            List<Tuple<string, string, int, bool>> TupleList2 = new List<Tuple<string, string, int, bool>>();

            Tuple<string, string, int, bool> FTuple1 = Tuple.Create("Cadena", "string", 0, false);

            TupleList2.Add(FTuple1);

            TupleList.ForEach(Console.WriteLine);
            Console.WriteLine();
            TupleList2.ForEach(Console.WriteLine);
            Console.WriteLine();

            /*Tipos por valor y referencia*/
            Stopwatch stopwatch = new Stopwatch();

            TestClass[] ClassArray = new TestClass[100000];
            TestStruct[] StructArray = new TestStruct[100000];

            stopwatch.Start();
            for (int i = 0; i < ClassArray.Length; i++)
            {
                ClassArray[i] = new TestClass("Name", "Descrip", DateTime.Now);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"Tiempo transcurrido en milisegundos: {ts.TotalMilliseconds}");

            stopwatch.Restart();
            for (int i = 0; i < StructArray.Length; i++)
            {
                StructArray[i] = new TestStruct(i, "Descrip", DateTime.Now);
            }
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine($"Tiempo transcurrido en milisegundos: {ts.TotalMilliseconds}\n");

            /*Colas, Listas, Diccionarios*/
            //Colas
            int[] ArrayQueue = new int[] {1, 2, 3, 4, 5, 6 , 7};

            stopwatch.Restart();
            ArrayQueue = ReverseWithQueue(ArrayQueue);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;

            Console.WriteLine($"Tiempo transcurrido: {ts.TotalSeconds}, primer dato invertido: {ArrayQueue[0]}");

            //Listas
            int[] ArrayList = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };

            stopwatch.Restart();
            ArrayList = ReverseWithList(ArrayList);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;

            Console.WriteLine($"Tiempo transcurrido: {ts.TotalSeconds}, primer dato invertido: {ArrayList[0]}");

            //Diccionarios
            int[] ArrayDictionary = new int[] { 1, 2, 3, 5, 7, 11, 13, 17 };
            

            stopwatch.Restart();
            ArrayDictionary = ReverseWithDict(ArrayDictionary);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;

            Console.WriteLine($"Tiempo transcurrido: {ts.TotalSeconds}, primer dato invertido: {ArrayDictionary[0]}");

            /*Pilas*/
            string MyPalindrome = "Anita lava la tina";
            Console.WriteLine(ItsPalindrome(MyPalindrome));

        }

        private static int[] ReverseWithQueue(int[] array)
        {
            Queue<int> QueueInverter = new Queue<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                QueueInverter.Enqueue(array[i]);
            }
            array = QueueInverter.ToArray();
            return array;
        }

        private static int[] ReverseWithList(int[] array)
        {
            List<int> ListInverter = new List<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                ListInverter.Add(array[i]);
            }
            array = ListInverter.ToArray();
            return array;
        }

        private static int[] ReverseWithDict(int[] array)
        {
            Dictionary<int, int> DictInverter = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                DictInverter.Add(i,array[i]);
            }

            array = DictInverter.Values.Reverse().ToArray();

            return array;
        }

        private static bool ItsPalindrome(string phrase)
        {
            phrase = phrase.ToLower();
            phrase = phrase.Replace(" ", "");

            Stack<string> Palindrome = new Stack<string>();
            char[] Chars = phrase.ToCharArray();

            string Comprobation = "";

            foreach (var character in Chars)
            {
                Palindrome.Push(character.ToString());
            }

            for (int i = Palindrome.Count - 1; i >= 0; i--)
            {
                Comprobation+=Palindrome.Pop();
            }

            if (Comprobation == phrase)
                return true;
            return false;
        }

    }

    internal class TestClass
    {
        private string _Name { get; set; }
        private string _Description { get; set; }
        private DateTime _Date { get; set; }
        internal TestClass(string name, string description, DateTime date)
        {
            _Name=name;
            _Description=description;
            _Date=date;
        }
    }

    internal struct TestStruct
    {
        private int _Id { get; set; }
        private string _Details { get; set; }
        private DateTime _Creation { get; set; }

        internal TestStruct(int id, string details, DateTime creation)
        {
            _Id=id;
            _Details=details;
            _Creation=creation;
        }
    }
}
