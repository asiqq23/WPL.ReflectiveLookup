using System;

namespace WPL.ReflectiveLookup.Examples
{
    public class A : Base
    {
        public override void Hello()
        {
            base.Hello();
            Console.WriteLine("a");
        }
    }
}