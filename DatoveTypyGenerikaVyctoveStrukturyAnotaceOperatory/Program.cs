#define abc

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Cache;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maturita
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // datove typy

            // value data types, stored in stack
            // tady muzete rict stack vs halda
            int a = 10;
            bool pravda = true;
            char c = 'a';
            float abc = 10.123456f;

            // reference data types
            string slovo = "abc";  // reference na haldu
            Person person = new Person() {  Age = 10 };

            // generika, dava uzivateli moznost zvolit svuj datovy typ
            // take ukazte jak interfacy spolupracuji s generikou
            List<string> vocabulary = new List<string>() { "abc", "bcd", "ddd" };

            // vyctove - enum
            PayMe(Payment.PayPal);

            // struktury - value data type
            // pouzivame pro presun dat, bez referenci
            Report rep = new Report() { Title="aaa", Pages=100};
            Report repCopy = rep; //copy into stack, tedy jsou to dva ruzne objekty,
            // kdybych kopiroval tridu tak oni oboje by mela stejny refernce tedy dva ukazatele
            // na jeden objekt


            // anotace
            person.GetInstance(10);
            person.Method();


            var attrs = typeof(Person).GetCustomAttributes(true);

            foreach (var attr in attrs)
                Console.WriteLine("Attribute on MyClass: " + attr.GetType().Name);
            // operatory



            
        }

        public struct Report
        {
            public string Title;
            public int Pages;
        }

        public enum Payment
        {
            PayPal,
            GooglePay,
            Visa
        }

        public static void PayMe(Payment paymentMethod)
        {
            switch (paymentMethod)
            {
                case Payment.PayPal:
                    Console.WriteLine("Paypal");
                    break;
                case Payment.GooglePay:
                    Console.WriteLine("GooglePay");
                    break;
                case Payment.Visa:
                    Console.WriteLine("Visa");
                    break;
                default: 
                    Console.WriteLine("Wrong");
                    break;

            }
        }

        public interface DAO<T>
        {
            public T GetInstance(int ID);
        }

        [Serializable]
        public class Person : DAO<Person>
        {
            [Required(ErrorMessage = "Name can't be null")]
            public string Name { get; set; }
            [Required]
            public int Age { get; set; }

            [Conditional("abc")]
            public void Method()
            {
                Console.WriteLine("Conditional method");
            }


            [Obsolete("this is method is old asf")]
            public Person GetInstance(int ID)
            {
                return null;
            }
        }
    }
}