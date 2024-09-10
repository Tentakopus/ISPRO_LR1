using System;
using Task6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegularUse()
        {
            int[,] arr = { {1, 2, 3, 4, 5, 6},
                           {3, 4, 6, 1, 2, 2},
                           {3, 4, 6, 1, 2, -10},
                           {5, 5, 5, 5, 5, 5},
                           {1, 2, 56, 42, 56, 56} };
            int[,] result;
            int[] indexes;
            int[] max = Class2DArray.FindMax(arr, out result, out indexes);
            Assert.AreEqual(2, result.GetLength(0));
            int[,] temp = { {3, 4, 6, 1, 2, 2},
                            {3, 4, 6, 1, 2, -10} };
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Assert.AreEqual(temp[i, j], result[i, j]);
                }
            }
            Assert.AreEqual(6, max[0]);
            Assert.AreEqual(6, max[1]);
            Assert.AreEqual(6, max[2]);
            Assert.AreEqual(5, max[3]);
            Assert.AreEqual(56, max[4]);
        }
        [TestMethod]
        public void NoDeletedElements() {
            int[,] arr = { {1, 9, 2, 1, 6, 6},
                           {5, 2, 7, 6, 1, 2},
                           {8, 7, 2, 1, 6, -10},
                           {2, 2, 7, -5, 9, 5},
                           {8, 1, 0, 2, 5, -5} };
            int[,] result;
            int[] indexes;
            int[] max = Class2DArray.FindMax(arr, out result, out indexes);
            Assert.AreEqual(arr.GetLength(0), result.GetLength(0));
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Assert.AreEqual(arr[i, j], result[i, j]);
                }
            }
            Assert.AreEqual(9, max[0]);
            Assert.AreEqual(7, max[1]);
            Assert.AreEqual(8, max[2]);
            Assert.AreEqual(9, max[3]);
            Assert.AreEqual(8, max[4]);
        }
        [TestMethod]
        public void AllElementsDeleted() {
            int[,] arr = { {1, 9, 2, 1, 6, 60},
                           {5, 2, 7, 6, 1, 20},
                           {8, 7, 2, 1, 6, 100},
                           {2, 2, 7, -5, 9, 50},
                           {8, 1, 0, 2, 5, 50} };
            int[,] result = { {1, 2, 3}, {1, 2, 3} };
            int[] indexes;
            int[] max = Class2DArray.FindMax(arr, out result, out indexes);
            Assert.IsNull(result);

            Assert.AreEqual(60, max[0]);
            Assert.AreEqual(20, max[1]);
            Assert.AreEqual(100, max[2]);
            Assert.AreEqual(50, max[3]);
            Assert.AreEqual(50, max[4]);
        }
        public void TestOneDimention() {
            int[,] arr = { { 1,9,2,1,6,60 } };

            int[,] result;
            int[] indexes;
            int[] max = Class2DArray.FindMax(arr,out result, out indexes);
            Assert.IsNull(result);
            Assert.AreEqual(1,max.Length);
            
            arr = null;
            arr = new int[,] { { 1 },{ 2 },{ -10 },{ 15 } };
            max = Class2DArray.FindMax(arr,out result, out indexes);
            Assert.IsNotNull(result);
            
            Assert.AreEqual(1,max[0]);
            Assert.AreEqual(2,max[1]);
            Assert.AreEqual(-10,max[2]);
            Assert.AreEqual(15,max[3]);
        }
        [TestMethod]
        public void TestRandomFill()
        {
            int[,] arr = Class2DArray.RandomFill(1, 10, 5, 2);
            Assert.IsNotNull(arr);
            Assert.AreEqual(5,arr.GetLength(0));
            Assert.AreEqual(2,arr.GetLength(1));

            try
            {
                arr = Class2DArray.RandomFill(10,-1,5,2);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Границы случайных чисел для заполнения массива заданы некорректно.", ex.Message);
            }
            try
            {
                arr = Class2DArray.RandomFill(10,10,5,2);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Границы случайных чисел для заполнения массива заданы некорректно.",ex.Message);
            }
            try
            {
                arr = Class2DArray.RandomFill(10,14,-1,2);
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Длина массива должна быть больше 0.",ex.Message);
            }
        }
    }
}
