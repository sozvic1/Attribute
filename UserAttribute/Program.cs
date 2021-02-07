using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAttribute
{
    enum Access
    {
        low,
        middle,
        high
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class AccessLevelAttribute : System.Attribute
    {
        public Access Level { get; set; }

        public AccessLevelAttribute(Access level)
        {
            Level = level;
            Employeer = new List<Employee>();


        }
        public List<Employee> Employeer { get; set; }
    }
    public class Employee
    {
        public void AccessAction()
        {
            Console.WriteLine("Уровень Доступа ");
        }
    }
   
    [AccessLevelAttribute(Access.low)]
    public class Manager : Employee
    {

    }
  
    [AccessLevelAttribute(Access.middle)]
    class Programmer : Employee
    {

    }
    [AccessLevelAttribute(Access.high)]

    class Director : Employee
    {

    }

    class Program
    {

        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.TryToAccess();
        }

    }
    //[AccessLevelAttribute(Access.low)]
    //[AccessLevelAttribute(Access.middle)]
    //[AccessLevelAttribute(Access.high)]
    public class MyClass
    {
        Employee[] employees;
        public MyClass()
        {
            employees = new Employee[] { new Manager(), new Programmer(), new Director() };
        }

        public void TryToAccess()
        {
            for (int i = 0; i < employees.Length; i++)
            {

                Console.WriteLine("Работник: {0}", employees[i].GetType().Name);
                employees[i].AccessAction();
                Type type = employees[i].GetType();
                object[] attributes = type.GetCustomAttributes(false);
                foreach (AccessLevelAttribute att in attributes)
                {
                    if (att.Level == Access.low) Console.WriteLine("Отказано");
                    if (att.Level == Access.middle) Console.WriteLine("Неполный доступ");
                    if (att.Level == Access.high) Console.WriteLine("Доступ разрешен");
                }
                Console.WriteLine();

            }
        }
    }
}
