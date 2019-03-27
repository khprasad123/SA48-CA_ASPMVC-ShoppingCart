using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsting
{
    class Program
    {
        static string[] RemArray = new string[6] { "A", "B", "C", "D", "E", "F" };
        static void Main()
            {
                Console.WriteLine("Input in a decimal number: ");
                int Hex = int.Parse(Console.ReadLine());
                Console.WriteLine("Converted Hex number : "+HexConvert(Hex));
            }

        static string HexConvert(int num) //Don't forget to pass your argument of Hex here!
        {
            string s = "",t="";   ///for storing purpose
            int res = num;
            int reminder;
                while (res != 0)
                {
                    reminder = res % 16;
                    res = res / 16;
                    t = reminder.ToString();  //for holding the reminder 
                      if (reminder > 9)
                      {
                          t = RemArray[reminder - 10]; ///instead of going to the function we can get the Correct hex correspondent by this 
                      }
                    s += t;
                }
            //next step is to reverse the string for getting correct Hex
            // REVERSED STRING IS THE ORIGINAL HEX NUMBER -------CHECK THE ALGORITHM IF YOU WANT
            t = "";   //clearing for storing the value;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                t += s[i];
            }

            return t;
        }

        }
    }
    

