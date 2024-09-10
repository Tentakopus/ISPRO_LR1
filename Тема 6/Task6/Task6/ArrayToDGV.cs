using System;
using System.Windows.Forms;

namespace Task6
{
    public class ArrayToDGV
    {
        /// <summary>
        /// Метод для преобразования двумерного масива целых чисел в таблицу DataGridView
        /// </summary>
        /// <param name="arr"> Массив, который необходимо преобразовать в таблицу</param>
        /// <param name="dgv"> Таблица DataGridView, в которую будет записан массив</param>
        static public void ConvertToDGV (int[,] arr, DataGridView dgv)
        {
            try
            {
                // Задание размеров таблицы
                dgv.RowCount = arr.GetLength(0);
                dgv.ColumnCount = arr.GetLength(1);

                // Цикл для прохода по всем элементам
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        dgv[j, i].Value = arr[i, j];
                    }
                }
            }
            catch (Exception)
            {
                // Исключение преобразования
                throw new Exception("Не удалось конвертировать двумерный массив в таблицу!");
            }
        }
        /// <summary>
        /// Метод для преобразования таблицы DataGridView в целочисленный двумерный массив
        /// </summary>
        /// <param name="dgv"> Таблица DataGridView, из которой необходимо достать массив </param>
        /// <returns> Двумерный целочисленный массив, полученный из таблицы</returns>
        static public int[,] ConvertToArray (DataGridView dgv)
        {
            try
            {
                // Возвращаемый двумерный массив
                int[,] result = new int[dgv.RowCount, dgv.ColumnCount];
                // Цикл для прохода по всем элементам таблицы
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        result[i, j] = Convert.ToInt32(dgv[j, i].Value);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                // Исключение преобразования
                throw new Exception("Не удалось конвертировать таблицу в двумерный массив!");
            }
        }
    }
}
