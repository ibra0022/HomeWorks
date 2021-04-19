using System;
using System.Collections.Generic;

namespace NumMatch
{
    class Program
    {
        public static bool match(string numbers)
        {
            //Stack<char> myStack = new Stack<char>(); 
            
            int[] myArray = new int[10];

            //string res = numbers;


            foreach(var ch in numbers)
            {
                //myStack.Push(ch);

                int index = (int)Char.GetNumericValue(ch);
                myArray[index]++;
            }
            foreach(var num in myArray)
            {
                //res += myStack.Pop();

                if(num % 2 == 1)
                {
                    return false;
                }

            }
            return true;
            //return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(match("12232231"));   
        }
    }
}
