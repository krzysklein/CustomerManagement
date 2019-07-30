using CustomerManagement.Common.SharedKernel;
using System;

namespace CustomerManagement.Domain.Customers
{
    public class TagColor : Enumeration
    {
        public string ColorValue { get; }

        private TagColor()
        {
        }

        public TagColor(Guid id, string name, string colorValue)
            : base(id, name)
        {
            if (string.IsNullOrWhiteSpace(colorValue)) throw new ArgumentException("Color value is invalid");

            ColorValue = colorValue;
        }

        #region Seed
        public static TagColor Red = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-000000FF3300"), "Red", "FF3300");
        public static TagColor Yellow = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-000000FFCC33"), "Yellow", "FFCC33");
        public static TagColor Orange = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-000000FF6600"), "Orange", "FF6600");
        public static TagColor Green = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-000000009933"), "Green", "009933");
        public static TagColor Teal = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-000000669999"), "Teal", "669999");
        public static TagColor Blue = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-0000000000CC"), "Blue", "0000CC");
        public static TagColor Purple = new TagColor(new Guid("FFFFFFFF-FFFF-FFFF-FFFF-0000006600CC"), "Purple", "6600CC");
        #endregion Seed
    }
}
