using CustomerManagement.Common.SharedKernel;
using System;

namespace CustomerManagement.Domain.Customers
{
    public class Tag : ValueObject
    {
        public string Name { get; }
        public TagColor Color { get; }

        private Tag()
        {
        }

        public Tag(string name, TagColor color)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Tag name is invalid");
            if (color == null) throw new ArgumentException("Color is invalid");

            Name = name;
            Color = color;
        }
    }
}
