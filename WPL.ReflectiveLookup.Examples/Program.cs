using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace WPL.ReflectiveLookup.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var instances = new Reflective<Base>()
                .Abstract(() => false)
                .Lookup()
                .WithInstances();

            foreach (var instance in instances)
            {
                instance.Hello();
            }

            var instances2 = new Reflective<Base>()
                .Abstract(() => false)
                .Lookup()
                .FullNames();

            foreach (var ins in instances2)
            {
                Console.WriteLine(ins);
            }

            var instances3 = new Reflective<Base>()
                .Abstract(() => false)
                .Lookup()
                .WithAttribute(() => typeof(DisplayNameAttribute))
                .FullNames();


            foreach (var ins in instances3)
            {
                Console.WriteLine(ins);
            }

            Console.ReadKey();
        }
    }
}
