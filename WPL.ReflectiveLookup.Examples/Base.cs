using System;

namespace WPL.ReflectiveLookup.Examples
{
    public abstract class Base
    {
        public virtual void Hello()
        {
            Console.WriteLine("base");
        }
    }
}