using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popytka_Algorithma_Prima
{
    class Program
    {
        static int Size;
        public class Ret
        {
            public int number;
            public int Mass;
            public Ret(int number, int Mass) { this.number = number; this.Mass = Mass; }
        }

        public class E
        {
            public int a, b;
            public E(int a,int b) { this.a = a; this.b = b; }
        }
        static public List<int> ls = new List<int>();
        static public Queue<E> qw = new Queue<E>();
        static int[,] array;
        

        static void Main(string[] args)
        {
            Console.Write("Введите размер графа: ");
            Size = Convert.ToInt32(Console.ReadLine()) + 1;
            array = new int[Size, Size];
            for (int i = 1; i < Size; i++)
            {
                for (int j = 1; j < Size; j++)
                {
                    array[i,j] = 0;
                }
            }

            //i - строка


            for (int i = 1; i < Size; i++)
            {
                for (int j = 1; j < Size; j++)
                {
                    if (i != j)
                    {
                        Console.Write("Вводите массу ребра {0} - {1} : ", i, j);
                        int massa = Convert.ToInt32(Console.ReadLine());
                        array[i, j] = massa;
                    }
                }
            }

            Console.Write("С кого начать? ");
            int a = Convert.ToInt32(Console.ReadLine());
            ls.Add(a);

            while (ls.Count <= Size)
            {
                Run();
            }

            for (int i = 0; i < qw.Count; i++)
            {
                E e = qw.Dequeue();

                Console.WriteLine("Ребро {0} - {1}", e.a, e.b);
            }

            Console.ReadKey();
        }

        public static void Run()
        {
            int min = 1000;
            int index = 0;
            int index2 = 0;
            E e = new E(0, 0);

            for (int i = 1; i < Size; i++)
            {
                Console.WriteLine("Бежим по i = {0}",i);
                if (ls.Exists(x => x == i) )
                {
                    Console.WriteLine("{0} содержится в стеке",i);
                    Ret ret = SearchMin(i);

                    if (ret.Mass < min)
                    {
                        min = ret.Mass;
                        if (min < 1000)
                        {
                            index = i;
                            index2 = ret.number;
                            Console.WriteLine("Зашли в if, index = {0}", i);
                        }
                    }
                }   
            }
            ls.Add(index2);
            qw.Enqueue(new E(index, index2));
            Console.WriteLine("Добавили в стек {0}, к дереву вершина {1} - {2} \n", min, index, index2);

        }


        // Находит минимальный элемент в заданной строчке, учитывая, что он из новой вершины
        // добавляет его в дерево

        public static Ret SearchMin(int a)
        {
            int min = 1000;
            int index = 0;
            for (int j = 1; j < Size; j++)
            {
                Console.WriteLine("------------SearchMin array [{0},{1}] = {2} ",a , j, array[a,j]);
                if (!ls.Exists(x => x == j))
                {
                    if (array[a, j] < min && array[a, j]!=0)
                    {
                        Console.WriteLine("{0} меньше чем min = {1}", array[a, j], min);
                        min = array[a,j];
                        index = j;
                    }
                }
            }
            Console.WriteLine("Возвращаем минимум из строки {0}, min = {1}", index,min);
            
            return new Ret(index,min);
        } 
    }
}
