using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the original string  : ");
            string original = Console.ReadLine();
            Console.Clear();
            char[] holder= fill(original);
            int attempt = 0;
            string temp;
            do
            {
                temp = "";
                Console.Write("Enter a Character : ");attempt++;
                string input = Console.ReadLine();
                for(int i = 0; i < original.Length; i++)
                {
                    if (original[i] == input[0])
                    {
                        holder[i] = input[0];
                    }
                }
                print(holder);
                foreach (char i in holder)
                {
                    temp += i;
                }
            } while (temp!=original);
            Console.WriteLine("identified th whole word in " + attempt + " attempt");
        }
        
        static void print(char[] a)
        {
            foreach(char i in a)
            {
                if (i == ' ')
                    Console.Write(" ");
                else if (i == '_')
                    Console.Write("[]");
                else
                    Console.Write(i);
            }
            Console.WriteLine();
        }
       static char[] fill(string x)
        {
            char[] temp = new char[x.Length];
            for(int i = 0; i <x.Length; i++) {
                if (x[i] == ' ')
                    temp[i] = ' ';
                else
                    temp[i] = '_';
            }
            return temp;
        }
    }
}
