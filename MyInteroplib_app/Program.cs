using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInteropLib; 
 
namespace MyInteroplib_app
{
    class Program
    {
        static void Main()
        {
            FileCacheWrapper fileCache = new FileCacheWrapper(); //←[1] 
            bool result = fileCache.Load("Test.txt");            //←[2] 

            try
            {
                Console.WriteLine("Length={0}", fileCache.Length);  //←[3] 
                Console.WriteLine("{0}", (char)fileCache[2]);      //←[4] 
                Console.WriteLine("{0}", (char)fileCache[5]);
            }
            catch (Exception ex)  //←[5] 
            {
                Console.WriteLine(ex.GetType());
            }
            fileCache.Dispose();  //←[6] 
        }
    }
}
