namespace ConstChile.Indicators
{
    public class Dolar : Indicator
    {
        #region Equals
        protected bool Equals(Dolar other)
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
            return Equals((Dolar)((object)((Dolar)obj)));
        }
        #endregion
    }
}
