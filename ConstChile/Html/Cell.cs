namespace ConstChile.Html
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string ExpressionTemplate { get; set; }
        public string Value { get; set; }

        public string Expression()
        {
            return ExpressionTemplate.Replace("row", Row.ToString()).Replace("column", Column.ToString());
        }
    }
}