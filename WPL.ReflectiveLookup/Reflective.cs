using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WPL.ReflectiveLookup
{
    public class Reflective<TLookup> where TLookup : class
    {
        private List<Type> lookups = new List<Type>();
        private bool _withAbstract = true;

        public Reflective<TLookup> Lookup()
        {
            lookups = Assembly
                .GetAssembly(typeof(TLookup))
                .GetTypes()
                .Where(p => p.IsClass && p.IsAbstract == _withAbstract && p.IsSubclassOf(typeof(TLookup)))
                
                .ToList();

            return this;
        }

        public Reflective<TLookup> Sort()
        {
            lookups.Sort();

            return this;
        }

        public Reflective<TLookup> Abstract(Func<bool> withAbstract)
        {
            _withAbstract = withAbstract();

            return this;
        }

        public Reflective<TLookup> WithAttribute(Func<Type> withType)
        {
            lookups = lookups
                .Where(p => Attribute.GetCustomAttribute(p, withType()) != null)
                .ToList();

            return this;
        }

        public IEnumerable<TLookup> WithInstances(Func<object[]> args =null)
        {
            return lookups.Select(p => args != null
                ? (TLookup) Activator.CreateInstance(p, args())
                : (TLookup) Activator.CreateInstance(p));
        }

        public IEnumerable<string> Names()
        {
            return lookups.Select(p => p.Name);
        }

        public IEnumerable<string> FullNames()
        {
            return lookups.Select(p => p.FullName);
        }
    }
}
