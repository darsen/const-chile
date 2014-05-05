using System;

namespace ConstChile.Indicators
{
    public class UF : Indicator
    {
        #region Equals
        protected bool Equals(UF other)
        {
            return Value == other.Value && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((UF)((object)((UF)obj)));
        }
        #endregion
    }
}
