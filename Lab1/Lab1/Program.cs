
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lst = new MyList<int>();
            Console.WriteLine("---------------Adding---------------");
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);

            print(lst);

            Console.WriteLine("---------------Clear---------------");
            lst.Clear();
            print(lst);

            lst.Add(11);
            lst.Add(12);
            lst.Add(13);
            lst.Add(14);
            lst.Add(10);
            print(lst);


            Console.WriteLine();
            Console.WriteLine("---------------Contains---------------");
            Console.WriteLine(lst.Contains(11));
            Console.WriteLine(lst.Contains(1));


            Console.WriteLine("---------------Copy to---------------");
            int[] arr = new int[7];
            lst.CopyTo(arr, 0);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();


            Console.WriteLine("---------------Copy to---------------");
            int[] arr2 = new int[5];
            lst.CopyTo(arr2);

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write($"{arr2[i]} ");
            }
            Console.WriteLine();


            Console.WriteLine("---------------Copy to---------------");
            int[] arr3 = new int[10];
            lst.CopyTo(1, arr3, 2, 2);

            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write($"{arr3[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("---------------Contains---------------");
            Console.WriteLine(lst.Remove(13));
            print(lst);

            Console.WriteLine("---------------Index of---------------");
            Console.WriteLine(lst.IndexOf(10));
            Console.WriteLine(lst.IndexOf(13));
            print(lst);

            Console.WriteLine("---------------Insert---------------");
            lst.Insert(0, 20);
            print(lst);

            Console.WriteLine("---------------Remove at---------------");
            lst.RemoveAt(2);
            print(lst);


            Console.WriteLine("---------------Sort---------------");
            lst.Sort();
            print(lst); 
            

            Console.WriteLine("---------------Event---------------");
            lst.AddEvent(100, 1);
            print(lst);
            lst.AddEvent(200);
            print(lst);


            Console.WriteLine("-----------------------------Rectangle list-----------------------------");

            MyList<Rectangle> rectangles = new MyList<Rectangle>();
            Rectangle r1 = new Rectangle(11, 20);
            Rectangle r2 = new Rectangle(12, 13);
            Rectangle r3 = new Rectangle(10, 10);
            LengthComparer lengthComparer = new LengthComparer();

            rectangles.Add(r1);
            rectangles.Add(r2);
            rectangles.Add(r3);

            Console.WriteLine("---------------Sort---------------");
            rectangles.Sort();

            foreach(var value in rectangles)
            {
                Console.WriteLine($"{value.length}, {value.width}");
            }

            Console.WriteLine("---------------Sort---------------");
            rectangles.Sort(lengthComparer);

            foreach (var value in rectangles)
            {
                Console.WriteLine($"{value.length}, {value.width}");
            }


            Console.ReadLine();

        }

        public class Rectangle : IComparable<Rectangle>
        {
            public int length { get; }
            public int width { get;  }

            public Rectangle(int l, int w)
            {
                length = l;
                width = w;
            }

            public int CompareTo(Rectangle other)
            {
                int P = 2 * (length + width);
                int POther = 2 * (other.length + other.width);

                if (P > POther)
                    return 1;
                else if (P < POther)
                    return -1;
                else
                    return 0;
            }
        }

        public class LengthComparer : IComparer<Rectangle>
        { 
            public int Compare(Rectangle x, Rectangle y)
            {
                if (x.length > y.length)
                    return 1;
                else if (x.length == y.length)
                    return 0;
                else
                    return -1;

            }
        }
         
        static void print(MyList<int> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Console.Write($"{lst[i]} ");
            }
            Console.WriteLine();
        }
    }
}
