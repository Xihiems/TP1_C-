using System;
using System.IO;
using Newtonsoft.Json;

namespace TP1
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Exercise 1.1 \n");

            // Creation of multiplication from 1 to 10

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("\nTable of " + i + "\n");
                for (int j = 1; j < 11; j++)
                {
                    Console.WriteLine(i + "*" + j + "=" + (i * j));
                }
            }

            Console.WriteLine("\n Exercise 1.2 \n ");
            Console.WriteLine("\n The off number are : \n");

            //Catch the odd numbers of multiplication table from 1 to 10

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("\nTable of " + i + "\n");
                for (int j = 1; j < 11; j++)
                {
                    if (i * j % 2 == 1)
                    {
                        Console.WriteLine(i + "*" + j + "=" + (i * j));
                    }
                }
            }

            Console.WriteLine("\n Exercise 1.3 \n ");
            Console.WriteLine("\n The off number are : \n");

            //Catch the odd numbers of multiplication table from 1 to N with N < 1000(N number choose by the user

            int Number_user = AskUserForParameter();
            if (Number_user <= 1000)
            {
                for (int i = 1; i < Number_user; i++)
                {
                    Console.WriteLine("\nTable of " + i + "\n");
                    for (int j = 1; j < Number_user; j++)
                    {

                        Console.WriteLine(i + "*" + j + "=" + (i * j));

                    }
                }
            }
            else
            {
                Console.WriteLine(" \n N doit etre inférieur à 1000");
            }

            Console.WriteLine("\n Exercise 2.1 \n ");

            //Catch all the Prime number from 1 to N

            Console.WriteLine("Prime number");
            int NB_user = AskUserForParameter();
            PrimNumber(NB_user);

            Console.WriteLine("\n Exercise 2.2 \n ");

            //Uses fibonnacci sequence for a N number
            int Fibonnaci_number = AskUserForParameter();
            int N_Fibonnaci = Fibonnaci(Fibonnaci_number);
            Console.WriteLine("Fibonnaci of 4");
            Console.WriteLine(N_Fibonnaci);

            Console.WriteLine("\n Exercise 2.3 \n");

            //Uses factorielle function

            Console.WriteLine("2.3.a  result of factorielle 4" + factorielle(4));
            Console.WriteLine("2.3.b  result of factorielle 6" + factorielle(6));
            Console.WriteLine("2.3.c  Take to much time and doesn't work because this number take to many places in the memory of the computer");
            Console.WriteLine("2.3.d  it's a function which is called itself");

            Console.WriteLine("Exercise 3");

            //Catch the error without crash the program

            try
            {
                for (int i = -3; i < 3; i++)
                {
                    float result = 10 / PowerFunction(i);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The exception is : " + e);
            }

            Console.WriteLine("Exercise 4\n");

            //Creates squares

            Console.WriteLine("Example :\n");

            Console.WriteLine("square 1 1 :");
            rectangle(1, 1);

            Console.WriteLine("square 1 5 :");
            rectangle(1, 5);

            Console.WriteLine("square 4 1 :");
            rectangle(4, 1);
            Console.WriteLine("square 4 3 :");
            rectangle(4, 3);

            Console.WriteLine("Exercise 5\n");

            using (StreamReader r = new StreamReader("DOGE_AllDataPoints_3Days.json"))
            {
                string json = r.ReadToEnd();


                Root data = JsonConvert.DeserializeObject<Root>(json);
                Console.WriteLine("The json is converted and assign to an object");

            }
            
        }

        //all the function are below :

        private static int AskUserForParameter()
        {
            Console.WriteLine("Please write a number and press enter :");
            int.TryParse(Console.ReadLine(), out var result);
            return result;
            
        }

        private static void PrimNumber(int i)
        {
            for(var j=2;j<i; j++)
            {

                Boolean prime = true;
                for(var k=2;k <= Math.Sqrt(j);k++)
                {
                    if (j % k == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime == true)
                {
                    Console.WriteLine(j);
                }
                
            }

        }
        private static int Fibonnaci(int N)
        {

            int a = 0;
            int b = 1;
            if (N == 0)
            {
                return a;
            }
            else if (N == 1)
            {
                return b;
            }
            else
            {
                for (int i = 2; i < N; i++)
                {
                    b = a + b;
                    a = b;

                }
            }
            return a;
        }
        private static int factorielle(int N)
        {
            if (N == 0)
            {
                return 1;
            }
            else
            {
                var total = 1;
                for (int i = 1; i <= N; i++)
                {
                    total = total * i;
                }
                return total;
            }
        }
        private static int PowerFunction(int x)
        {
            return (int)(Math.Pow(x, 2) - 4);
        }

        private static void rectangle(int largeur, int longueur)
        {
            string rectangle = "";
            for (int i = 0; i < largeur; i++)
            {
                for(int j = 0; j < longueur; j++)
                {
                    if (i==0 && j == 0||i==largeur-1 && j==0||i==0 && j==longueur-1||i==largeur-1 && j==longueur-1)
                    {
                        rectangle += "o";
                    }
                    else if (j == 0 || j == longueur - 1)
                    {
                        rectangle += "|";
                    }
                    else if (i == 0 || i == largeur - 1)
                    {
                        rectangle += "-";
                    }
                    else
                    {
                        rectangle += " ";
                    }
                    
                   
                }
                rectangle += "\n";
            }
            Console.WriteLine(rectangle);
        }


    }
}
