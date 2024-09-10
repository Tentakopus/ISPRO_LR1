using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Class2DArray
    {
        public static int[,] RandomFill(int min, int max, int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new Exception("Длина массива должна быть больше 0.");
            if (min >= max) throw new Exception("Границы случайных чисел для заполнения массива заданы некорректно.");
            int[,] result = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i,j] = random.Next(min, max);
                }
            }
            return result;
        }

        public static int[] FindMax(int[,] arr, out int[,] result)
        {
            int[] max = new int[arr.GetLength(0)];
            List<int[]> temp = new List<int[]>();

            // Поиск максимальных элементов для каждой строки
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i,j] > max[i])
                    {
                        max[i] = arr[i,j];
                    }
                }
            }
            
            // Создание листа строк, в которых максимальный элемент не на последней позиции
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, arr.GetLength(1) - 1] != max[i])
                {
                    temp.Add(new int[arr.GetLength(1)]);
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        temp[temp.Count - 1][j] = arr[i, j];
                    }
                }
            }
            
            if (temp.Count > 0)
            {
                result = new int[temp.Count, arr.GetLength(1)];
                for (int i = 0; i < temp.Count; i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        result[i, j] = temp[i][j];
                    }
                }
            }
            else
            {
                result = null;
            }
            return max;
        }
    }
}
