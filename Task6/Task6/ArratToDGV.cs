using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class ArratToDGV
    {
        static public void ConvertToDGV (int[,] arr, DataGridView dgv)
        {
            dgv.RowCount = arr.GetLength(0);
            dgv.ColumnCount = arr.GetLength(1);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    dgv[j, i].Value = arr[i,j];
                }
            }
        }

        static public int[,] ConvertToArray (DataGridView dgv)
        {
            int[,] result = new int[dgv.RowCount, dgv.ColumnCount];
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    result[i, j] = Convert.ToInt32(dgv[j,i].Value);
                }
            }
            return result;
        }
    }
}
