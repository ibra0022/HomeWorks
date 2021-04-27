using System;
using System.IO;


namespace FilreReadWrite
{
    class Program
    {
        const string fileName = "D:\\myzip.zip";

        static void Main()
        {
            DisplayValues();
        }

        public static void DisplayValues()
        {
            byte[] magic = new byte[4];
            byte[] Version = new byte[2];
            byte[] GP = new byte[2];
            byte[] compressionMethod = new byte[2];
            byte[] modificationTime = new byte[2];
            byte[] modificationDate = new byte[2];


            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {

                    magic = reader.ReadBytes(4);
                    Version = reader.ReadBytes(2);
                    GP = reader.ReadBytes(2);
                    compressionMethod = reader.ReadBytes(2);
                    modificationTime = reader.ReadBytes(2);
                    modificationDate = reader.ReadBytes(2);

                }
                if (magic[0] == 80 && magic[1] == 75 && magic[2] == 3 && magic[3] == 4)
                {
                    Console.WriteLine("this is a zip file");
                    Console.WriteLine("magic: " + magic[0] + " " + magic[1] + " " + magic[2] + " " + magic[3]);
                }

                if(Version[0] == 80 && Version[1] == 75)
                {
                    Console.WriteLine("the version is v2.0");
                    Console.WriteLine("Version: " + Version[1] + " " + Version[0]);
                }

                switch (GP[1])
                {
                    case 0:
                        switch (GP[0])
                        {
                            case 0:
                                Console.WriteLine("it is encrypted file");
                                break;
                            case 1:
                                Console.WriteLine("it is compression option file");
                                break;
                            case 2:
                                Console.WriteLine("it is compression option file");
                                break;
                            case 3:
                                Console.WriteLine("it is data descriptor file");
                                break;
                            case 4:
                                Console.WriteLine("it is enhanced deflation file");
                                break;
                            case 5:
                                Console.WriteLine("it is compressed patched data file");
                                break;
                            case 6:
                                Console.WriteLine("it is strong encryption file");
                                break;
                            default:
                                Console.WriteLine("it is encrypted file");
                                break;
                        }
                        break;
                    case 1:
                        switch (GP[0])
                        {
                            case 1:
                                Console.WriteLine("it is language encoding ");
                                break;
                            case 2:
                                Console.WriteLine("it is reserved ");
                                break;
                            case 3:
                                Console.WriteLine("it is mask header values");
                                break;
                            case 4:
                                Console.WriteLine("it is reserved");
                                break;
                            case 5:
                                Console.WriteLine("it is reserved");
                                break;
                            default:
                                Console.WriteLine("it is encrypted file");
                                break;
                        }
                        break;

                }

                switch (compressionMethod[1])
                {
                    case 0:
                        switch (compressionMethod[0])
                        {
                            case 0:
                                Console.WriteLine("no compression");
                                break;
                            case 1:
                                Console.WriteLine("shrunk");
                                break;
                            case 2:
                                Console.WriteLine("reduced with compression factor 1");
                                break;
                            case 3:
                                Console.WriteLine("reduced with compression factor 2");
                                break;
                            case 4:
                                Console.WriteLine("reduced with compression factor 3");
                                break;
                            case 5:
                                Console.WriteLine("reduced with compression factor 4");
                                break;
                            case 6:
                                Console.WriteLine("imploded");
                                break;
                            case 7:
                                Console.WriteLine("reserved");
                                break;
                            case 8:
                                Console.WriteLine("deflated");
                                break;
                            case 9:
                                Console.WriteLine("enhanced deflated");
                                break;
                        }
                        break;
                    case 1:
                        switch (compressionMethod[0])
                        {
                            case 0:
                                Console.WriteLine("PKWare DCL imploded");
                                break;
                            case 1:
                                Console.WriteLine("reserved");
                                break;
                            case 2:
                                Console.WriteLine(" compressed using BZIP2");
                                break;
                            case 3:
                                Console.WriteLine("reserved");
                                break;
                            case 4:
                                Console.WriteLine("LZMA");
                                break;
                            case 5:
                                Console.WriteLine("reserved");
                                break;
                            case 6:
                                Console.WriteLine("reserved");
                                break;
                            case 7:
                                Console.WriteLine("reserved");
                                break;
                            case 8:
                                Console.WriteLine("compressed using IBM TERSE");
                                break;
                            case 9:
                                Console.WriteLine("IBM LZ77 z");
                                break;
                        }
                        break;

                }

                
                Console.WriteLine("modification Time is in decimal: " + modificationTime[1] + " " + modificationTime[0]);
                Console.WriteLine("modification Time is in binary: " + toBi(modificationTime[1]) + toBi(modificationTime[0]));
                string time = toBi(modificationTime[1]) + toBi(modificationTime[0]);
                int hour = Convert.ToInt32(time.Substring(0, 5), 2);
                int min = Convert.ToInt32(time.Substring(5, 6), 2);
                int sec = Convert.ToInt32(time.Substring(11, 5), 2);
                Console.WriteLine("modification Time: " + hour + ":" + min + ":" + sec);


                Console.WriteLine("modification Date is in decimal: " + modificationDate[1] + " " + modificationDate[0]);
                Console.WriteLine("modification Date is in binary: " + toBi(modificationDate[1]) + toBi(modificationDate[0]));
                string date = toBi(modificationDate[1]) + toBi(modificationDate[0]);
                int year = Convert.ToInt32(date.Substring(0, 7), 2);
                int month = Convert.ToInt32(date.Substring(7, 4), 2);
                int day = Convert.ToInt32(date.Substring(11, 5), 2);
                Console.WriteLine("modification Date: " + year + "/" + month + "/" + day);

            }
        }

        public static string toBi(int num)
        {
            string result;
            string newRes = "";

            result = "";
            while (num > 1)
            {
                int remainder = num % 2;
                result = Convert.ToString(remainder) + result;
                num /= 2;
            }
            result = Convert.ToString(num) + result;

            if (result.Length < 8)
            {
                int re = 8 - result.Length;
                
                for (int i = 0; i < re; i++)
                {
                    newRes += "0";
                }
            }
            newRes += result;
            return newRes;
        }
    }
}
