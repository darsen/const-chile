using System;
using System.ComponentModel.DataAnnotations;

namespace ConstChile.Indicators
{
    public class Indicator
    {
        [Key]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode()*397) ^ Date.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Date: {0}, Value: {1}", Date, Value);
        }
    }
}