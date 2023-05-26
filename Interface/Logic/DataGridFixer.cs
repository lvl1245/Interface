using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class DataGridFixer
    {

        //убирает колонки с конца
        public static void FixTable(int lastColumNumber, DataGridView viewTofix)
        {
            for (int i = 1; i < lastColumNumber + 1; i++)
            {
                viewTofix.Columns[viewTofix.Columns.Count - i].Visible = false;
            }
        }
        // убирает выбранные колонки
        public static void FixTable(DataGridView viewTofix, params int[] columnNumbers)
        {
            for (int i = 0; i < viewTofix.ColumnCount; i++)
            {
                if (columnNumbers.Contains(i))
                {
                    viewTofix.Columns[i - 1].Visible = false;
                }
            }
        }
    }
}
