using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projDFScsharp
{


    class Program
    {
        public static string[,] TWODArray = new string[20, 30];

        public static void Random(int frequency)
        {
            Random rnd = new Random();
            for (int i = 0; i < frequency ; i++)
            {
                
                int num1 = rnd.Next(1, 28);
                int num2 = rnd.Next(1, 19);
                TWODArray[num2, num1] = "_0_";
            }

           

        }
       
        public static int startD = 10, startQ = 17, EndD = 11, EndQ = 18;
        public static int top = -1;
        public static int counter = 1;

        public static string[] stack = new string[600];


        public static string pop()
        {
            return stack[top--];
        }


        public static void  push(int in1, int in2)
        {
             stack[++top] = in1.ToString() +","+ in2.ToString();
        }


        public static string peek()
        {
            return stack[top];
        }

        public static void intizialize()
        {


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {

                    if (j == 0 || i == 0 || i == 19 || j == 29)
                    {
                        TWODArray[i, j] = "_0_";

                    }
                    else
                    {
                        TWODArray[i, j] = "_1_";

                    }

                }

            }

            //TWODArray[startD, startQ] = "_s_";
            //TWODArray[EndD, EndQ] = "_e_";
            //TWODArray[stop1D, stop1Q] = "_0_";
            //TWODArray[stop2D, stop2Q] = "_0_";
            //TWODArray[stop3D, stop3Q] = "_0_";
            //TWODArray[stop4D, stop4Q] = "_0_";
            //TWODArray[stop5D, stop5Q] = "_0_";
            //TWODArray[stop6D, stop6Q] = "_0_";
        }

        public static void display()
        {
            string all="";
            for (int i   = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(TWODArray[i,j]+"  ");
                    all += TWODArray[i, j] + "  ";
                }
                all += "\n";
                Console.WriteLine();
            }
            File.WriteAllText("G:\\log\\onne.txt",all);
        }

        public static string Counter(int up)
        {
            if(up == 1)
            {
                counter++;
                if (counter <= 9)
                {
                    return "_" + counter.ToString() + "_";
                }
                else if (counter >= 10 && counter <= 99)
                {
                    return counter.ToString() + "_";
                }
                else
                {
                    return counter.ToString();
                }
            }
            else
            {
                counter--;
                if (counter <= 9)
                {
                    return "_" + counter.ToString()+"_";
                }
                else if (counter >= 10 && counter <= 99)
                {
                    return "_"+counter.ToString();
                }
                else
                {
                    return counter.ToString();
                }
            }
            
          
        }

 
        public static bool Founded()
        {
            if (TWODArray[startD - 1, startQ] == "_e_")
            {

                string message = "we found the way";
                MessageBox.Show(message);
                return true;
            }
            else if (TWODArray[startD - 1, startQ] != "_1_" && TWODArray[startD, startQ + 1] == "_e_")
            {

                string message = "we found the way";
                MessageBox.Show(message);
                return true;
            }
            else if (TWODArray[startD - 1, startQ] != "_1_" && TWODArray[startD, startQ + 1] != "_1_" && TWODArray[startD + 1, startQ] == "_e_")
            {

                string message = "we found the way";
                MessageBox.Show(message);
                return true;
            }
            else if (TWODArray[startD - 1, startQ] != "_1_" && TWODArray[startD, startQ + 1] != "_1_" && TWODArray[startD + 1, startQ] != "_1_" && TWODArray[startD, startQ - 1] == "_e_")
            {

                string message = "we found the way";
                MessageBox.Show(message);
                return true;
            }
            return false;

        }

        public static void lastResult()
        {
            counter = top+3;
            while (top != -1)
            {
                string temp;
                temp = pop();
                startD = Int32.Parse(temp.Split(',')[0]);
                startQ = Int32.Parse(temp.Split(',')[1]);
                TWODArray[startD, startQ] = Counter(0);
            }
        }
        public static void FindWay()
        {
            

            if (Founded())
            {
                return;
            }

            if (TWODArray[startD - 1, startQ] == "_1_")
            {

                startD -= 1;
                push(startD, startQ);
                TWODArray[startD, startQ] = "_v_";
                    //Counter(1);
                //"6";
                FindWay();
            }
            else if (TWODArray[startD, startQ + 1] == "_1_")
            {

                startQ += 1;
                push(startD, startQ);
                TWODArray[startD, startQ] = "_v_";
                // Counter(1);
                //"6";
                FindWay();
            }
            else if (TWODArray[startD + 1, startQ] == "_1_")
            {

                startD += 1;
                push(startD, startQ);
                TWODArray[startD, startQ] = "_v_";
                //Counter(1);
                //"6";
                FindWay();
            }
            else if (TWODArray[startD, startQ - 1] == "_1_")
            {

                startQ -= 1;
                push(startD, startQ);
                TWODArray[startD, startQ] = "_v_";
                //Counter(1);
                //"6";
                FindWay();
            }
            else
            {
                TWODArray[startD, startQ] = "_p_";
                //counter--;
                string temp;
                temp = pop();
                startD = Int32.Parse(temp.Split(',')[0]);
                startQ = Int32.Parse(temp.Split(',')[1]);
                FindWay();

            }



        }
        static void Main(string[] args)
        {
            intizialize();
            display();

            Console.WriteLine("enter start row and column  ");
            startD = Int32.Parse(Console.ReadLine());
            startQ = Int32.Parse(Console.ReadLine());
            TWODArray[startD, startQ] = "_s_";
            Console.WriteLine("enter end row and column  ");
            EndD = Int32.Parse(Console.ReadLine());
            EndQ = Int32.Parse(Console.ReadLine());

            TWODArray[EndD, EndQ] = "_e_";

            Console.WriteLine("if random Enter Random Num: 1 " +
                "if yourself enter num 2");


            int type_input = Int32.Parse(Console.ReadLine());
            if (type_input == 1)
            {
                int Random_num = Int32.Parse(Console.ReadLine());
                Random(Random_num);
                FindWay();
                lastResult();
                display();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Enter Number of _0_ or blocked place:");
                int reapeated = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < reapeated; i++)
                {
                    Console.WriteLine("Enter row :");
                    int first = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter culomn :");
                    int second = Int32.Parse(Console.ReadLine());
                    TWODArray[first, second] = "_0_";
                    FindWay();
                    lastResult();
                    display();
                    Environment.Exit(0);
                }
            }
            
           

            Console.ReadLine();

        }
    }
}
