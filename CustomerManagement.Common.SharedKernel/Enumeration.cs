using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomerManagement.Common.SharedKernel
{
    public abstract class Enumeration : Entity
    {
        public string Name { get; private set; }

        protected Enumeration()
            : base(newId: false)
        {
        }

        protected Enumeration(Guid id, string name)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is invalid");

            Name = name;
        }

        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields
                .Select(field => field.GetValue(null))
                .Cast<T>();
        }
    }
}
