using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MatrixMethods
    {
        public int[] FindMax(int[,] arr)
        {
            List<int[]> result = new List<int[]>();
            List<int> maxArr = new List<int>();
            List<int> deleteStr = new List<int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result.Add(new int[arr.GetLength(1)]);
                maxArr.Add(arr[i, 0]);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result[i][j] = arr[i, j];
                    if (maxArr[i] <=  arr[i, j])
                    {
                        maxArr[i] = arr[i, j];
                        if (j == arr.GetLength(1) - 1) deleteStr.Add(i);
                    }
                }
            }
            for (int i = 0; i < deleteStr.Count; i++)
            {
                maxArr.RemoveAt(i);
                result.RemoveAt(i);
            }

            return result.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}
