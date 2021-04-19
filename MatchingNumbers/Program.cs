using System;

namespace NumMatch
{
    class Program
    {
        public static bool match(string numbers)
        {
            //Stack<char> myStack = new Stack<char>(); 

            if (numbers.Length % 2 != 0)
                return false;

            int half = numbers.Length / 2;
            
            //int[] myArray = new int[10];

            char[] myArray2 = new char[half];

            //string res = numbers;


            /*foreach(var ch in numbers)
            {
                //myStack.Push(ch);

                int index = (int)Char.GetNumericValue(ch);
                myArray[index]++;

            }*/

            for(int i = 0; i < half; i++)
            {
                myArray2[i] = numbers[i];
            }

            int count = 0;

            for(int i = numbers.Length - 1; i >= half; i--)
            {
                if (numbers[i] != myArray2[count])
                    return false;
                count++;
            }

            /*foreach(var num in myArray)
            {
                //res += myStack.Pop();

                if(num % 2 == 1)
                {
                    return false;
                }

            }*/

            return true;
            //return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(match("122334433221"));   
        }
    }
}
