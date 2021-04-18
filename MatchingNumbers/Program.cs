using System;
using System.Collections.Generic;

namespace NumMatch
{
    class Program
    {
        public static string match(string numbers)
        {
            Stack<char> myStack = new Stack<char>();
            string res = numbers;

            foreach(var ch in numbers)
            {
                myStack.Push(ch);
            }
            foreach(var ch in numbers)
            {
                res += myStack.Pop();
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(match("1232343455676"));   
        }
    }
}
