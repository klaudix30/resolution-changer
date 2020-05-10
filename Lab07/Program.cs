
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    class Program
    {
        static ResolutionChanger rc;
     
        static void checkDirectory(int resX,int resY, string input,string output)
        {
            string path = output + "\\" + "output";
            Directory.CreateDirectory(path);
            rc = new ResolutionChanger(resX, resY, input, path);
        }
        


        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("nie podano zadnych parametrow");
            }
            else
            {
                
                if (args[0].Contains("x"))
                { 
                    var divide = args[0].Split('x');
                    if(!int.TryParse(divide[0],out int resx) || !int.TryParse(divide[1], out int resy))
                    {
                        Console.WriteLine("rozdzielczosc nie moze byc typu double");
                        Environment.Exit(0);
                    }

                    if (args.Length == 1)
                    {
                       
                        checkDirectory(Int32.Parse(divide[0]), Int32.Parse(divide[1]), Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory());
                    }
                    else if(args.Length == 2 && Directory.Exists(args[1]))
                    {
                     
                            checkDirectory(Int32.Parse(divide[0]), Int32.Parse(divide[1]), args[1], Directory.GetCurrentDirectory());
                        
                      
                    }
                    else if(args.Length == 3 && Directory.Exists(args[1]) && Directory.Exists(args[2]))
                    {
                       
                            rc = new ResolutionChanger(Int32.Parse(divide[0]), Int32.Parse(divide[1]), args[1], args[2]);


                    }
                    else
                    {
                        Console.WriteLine("sciezka nie istnieje");
                        Environment.Exit(0);
                    }

                    rc.getFiles();
                    Console.WriteLine("Zakonczono");
                }
                else
                {

                    Console.Write("bledny format rozdzielczosci");
                    
                }
              

            }
            

        }
    }
}
