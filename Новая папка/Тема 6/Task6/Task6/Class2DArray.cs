using System;
using System.Collections.Generic;

namespace Task6
{
    public class Class2DArray
    {
        /// <summary>
        /// Метод для случайного заполнения двумерного массива
        /// </summary>
        /// <param name="min"> Минимальное значение элемента массива</param>
        /// <param name="max"> Максимальный предел значений элемента массива</param>
        /// <param name="rows"> Количество рядов в двумерном массиве</param>
        /// <param name="columns"> Количество столбцов в двумерном массиве</param>
        /// <returns> Двумерный массив, заполненный случайными значениями</returns>
        public static int[,] RandomFill(int min, int max, int rows, int columns)
        {
            // Исключение: числа должны быть неотрицательными
            if (rows <= 0 || columns <= 0) throw new Exception("Длина массива должна быть больше 0.");
            // Исключение: Максимальный предел должен быть больше минимального значения
            if (min >= max) throw new Exception("Границы случайных чисел для заполнения массива заданы некорректно.");
            // Объявление нового двумерного массива
            int[,] result = new int[rows, columns];
            Random random = new Random();
            // Заполнение двумерного массива случайными значениями
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i,j] = random.Next(min, max);
                }
            }
            return result;
        }
        /// <summary>
        /// Метод для поиска максимальных элементов в строках двумерного массива
        /// </summary>
        /// <param name="arr"> Двумерный массив, в котором производится поиск максимальных элементов в строках. </param>
        /// <param name="result"> Двумерный массив, получаемый из исходного после удаления строк, где максимальные элементы стоят на последней позиции в строке. </param>
        /// <returns> Массив максимальных элементов по строкам. </returns>
        public static int[] FindMax(int[,] arr, out int[,] result)
        {
            // Массив максимальных элементов
            int[] max = new int[arr.GetLength(0)];
            // Лист массивов, отражающий строки, которые 
            List<int[]> temp = new List<int[]>();

            // Поиск максимальных элементов для каждой строки
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                max[i] = arr[i,0];
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
        /// <summary>
        /// Метод для поиска максимальных элементов в строках двумерного массива
        /// </summary>
        /// <param name="arr"> Двумерный массив, в котором производится поиск максимальных элементов в строках. </param>
        /// <param name="result"> Двумерный массив, получаемый из исходного после удаления строк, где максимальные элементы стоят на последней позиции в строке. </param>
        /// <returns> Массив максимальных элементов по строкам. </returns>
        public static int[] FindMax(int[,] arr,out int[,] result, out int[] indexes)
        {
            // Массив максимальных элементов
            int[] max = new int[arr.GetLength(0)];
            // Лист массивов, отражающий строки, которые 
            List<int[]> temp = new List<int[]>();
            // Лист индексов строк, оставшихся после удаления
            List<int> indexList = new List<int>();
            // Поиск максимальных элементов для каждой строки
            for(int i = 0;i < arr.GetLength(0);i++)
            {
                max[i] = arr[i,0];
                for(int j = 0;j < arr.GetLength(1);j++)
                {
                    if(arr[i,j] > max[i])
                    {
                        max[i] = arr[i,j];
                    }
                }
            }

            // Создание листа строк, в которых максимальный элемент не на последней позиции
            for(int i = 0;i < arr.GetLength(0);i++)
            {
                if(arr[i,arr.GetLength(1) - 1] != max[i])
                {
                    indexList.Add(i);
                    temp.Add(new int[arr.GetLength(1)]);
                    for(int j = 0;j < arr.GetLength(1);j++)
                    {
                        temp[temp.Count - 1][j] = arr[i,j];
                    }
                }
            }

            if(temp.Count > 0)
            {
                result = new int[temp.Count, arr.GetLength(1)];
                for(int i = 0;i < temp.Count;i++)
                {
                    for(int j = 0;j < arr.GetLength(1);j++)
                    {
                        result[i,j] = temp[i][j];
                    }
                }
                indexes = indexList.ToArray();
            }
            else
            {
                indexes = null;
                result = null;
            }
            return max;
        }
    }
}
