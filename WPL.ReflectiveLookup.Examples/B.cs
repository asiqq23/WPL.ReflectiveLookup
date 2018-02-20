using System;
using System.ComponentModel;

namespace WPL.ReflectiveLookup.Examples
{
    [DisplayName("B")]
    public class B : Base
    {
        public override void Hello()
        {
            Console.WriteLine("b");
        }
    }
}