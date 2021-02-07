using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Student.PrintConsole();
            //Student.PrintConsole2();
            Console.ReadKey();
        }
        
        
    }
   
    public class Student
    {
        [Obsolete("Устаревший метод")]
        public static void PrintConsole()
        {
            Console.WriteLine("This is old version");
        }

        [Obsolete("Устаревший метод",error:true)]
        public static void PrintConsole2()
        {
            Console.WriteLine("This is old version");
        }
    }
}
