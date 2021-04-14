using System;

namespace tiwAccounts
{
    class Program
    {

        static void tokenizer(string value)
        {
            int i = 0;

            int numOfAccounts = 0;

           // Console.WriteLine("0");


            while(i < value.Length)
            {
                //Console.WriteLine("1");

                if (value[i].Equals('@'))
                {
                    //Console.WriteLine("2");
                    string account = "";

                    numOfAccounts++;
                    i++;

                    while(i < value.Length)
                    {
                        account += value[i];

                        if(value[i].Equals(' '))
                        {
                            break;
                        }

                        i++;
                    }
                    Console.WriteLine("the account number " + numOfAccounts + " is " +account);
                }

                i++;
            }

            Console.WriteLine();
            Console.WriteLine("the total number of all accounts is " + numOfAccounts);
        }

        static void Main(string[] args)
        {

            tokenizer("sdlkjghdflkjsg sdflkjhglsd gjlf sldf @lkjdghsdl ldsjhgfklh @ls fdlghjkfh @asdf asdasf @jjg");
        }
    }
}
