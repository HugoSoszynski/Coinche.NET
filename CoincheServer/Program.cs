using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AsyncListener.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(84);
            }
        }
    }
}
