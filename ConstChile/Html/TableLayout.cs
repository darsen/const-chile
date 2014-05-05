using System.Collections;

namespace ConstChile.Html
{
    public class TableLayout
    {
        public int ColumnCount;
        public int ColumnOffset;
        public int RowCount;
        public int RowOffset;
        public string XPathTemplate { get; set; }
        private int row;
        private int column;
        public IEnumerator GetEnumerator()
        {
            for (row = RowOffset; row < RowCount + RowOffset; row++)
            {
                for (column = ColumnOffset; column < ColumnCount + ColumnOffset; column++)
                {
                    yield return new Cell{Row = row, Column =  column, ExpressionTemplate = XPathTemplate};
                }
            }
        }
    }
}