using System;

namespace MyStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONBuilder json = new JSONBuilder();

            string res = json.beginSom("{")
                                    .setKey("firstname").setValue("IBRA").setComma()
                                    .setKey("lastname").setValue("HEEM").setComma()
                                    .setKey("location").beginSom("[")
                                                           .beginSom("{")
                                                                .setKey("lat").setValue("22.20").setComma()
                                                                .setKey("lon").setValue("39.91").setComma()
                                                           .endSom("}")
                                                        .endSom("]").setComma()
                                .endSom("}").getJSON();

            Console.WriteLine(res);
        }
    }

    class JSONBuilder
    {
        private string json;
        private int numOfTab = 0;
        bool tab = false;

        public JSONBuilder()
        {
            this.json = "";
        }
        public JSONBuilder beginSom(string value)
        {
            if (json.EndsWith(": "))
            {
                this.json += value + "\n";
                numOfTab++;    
                numOfTab++;
                //tab = true;
            } else
            {
                for (int i = 0; i < numOfTab; i++)
                {
                    this.json += "\t";
                }
                this.json += value + "\n";
                numOfTab++;
            }
            
            
            return this;
        } 
        public JSONBuilder setKey(string value)
        {
            for(int i = 0; i < numOfTab; i++)
            {
                this.json += "\t";
            }
            this.json += value + ": ";
            return this;
        }
        public JSONBuilder setValue(string value)
        {
            this.json += value;
            return this;
        }
        public JSONBuilder endSom(string value)
        {
            numOfTab--;
            /*if(tab)
            {
                numOfTab--;
                tab = false;
            }*/
            for (int i = 0; i < numOfTab; i++)
            {
                this.json += "\t";
            }
            

            this.json += value + "\n" ;
            

            return this;
        }
        public JSONBuilder setComma()
        {
            for (int i = 0; i < numOfTab; i++)
            {
                this.json += "\t";
            }
            this.json += ", \n";
            return this;
        }
        public string getJSON()
        {
            return this.json;
        }
    }
}
