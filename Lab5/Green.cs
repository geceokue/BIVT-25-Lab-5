using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int[] answer0 = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                int jMin = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        jMin = j;
                    }
                }
                answer0[i] = jMin;
            }
            answer = answer0;
            // end
            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int jMax = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jMax = j;
                    }
                }
                for(int j = 0; j < jMax; j++)
                {
                    if (matrix[i, j] < 0 && max != 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }
                }
            }
            // end
        }
        public void Task3(int[,] matrix, int k)
        {
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if ((m != n) || k >= n)
            {
                return;
            }
            int max = int.MinValue;
            int jMax = 0;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    jMax = i;
                }
            }
            if (k != jMax)
            {
                for (int i = 0; i < m; i++)
                {
                    (matrix[i, k], matrix[i, jMax]) = (matrix[i, jMax], matrix[i, k]);
                }
            }
            // end
        }
        public void Task4(int[,] matrix)
        {
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m != n)
            {
                return;
            }
            int jMax = -1;
            int max = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    jMax = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                (matrix[i, jMax], matrix[jMax, i]) = (matrix[jMax, i], matrix[i, jMax]);
            }
            // end
        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int sumMax = int.MinValue;
            int i0 = 0;
            for (int i = 0; i < m; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                if(sum > sumMax)
                {
                    sumMax = sum;
                    i0 = i;
                }
            }
            answer = new int[m - 1, n];
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i < i0)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }
            // end
            return answer;
        }
        public void Task6(int[,] matrix)
        {
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m <= 1)
            {
                return;
            }
            int countMax = int.MinValue;
            int countMin = int.MaxValue;
            int negMin = 0;
            int negMax = 0;
            for (int i = 0; i < m; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                if (count > countMax)
                {
                    countMax = count;
                    negMax = i;
                }
                if (count < countMin)
                {
                    countMin = count;
                    negMin = i;
                }
            }
            if (countMax != countMin)
            {
                for (int j = 0; j < n; j++)
                {
                    (matrix[negMax, j], matrix[negMin, j]) = (matrix[negMin, j], matrix[negMax, j]);
                }
            }
            // end
        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if(array.Length != m)
            {
                return matrix;
            }
            int min = int.MaxValue;
            int j0 = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        j0 = j;
                    }
                }
            }
            answer = new int[m, n + 1];
            int count = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n + 1; j++)
                {
                    if(j <= j0)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if(j == j0 + 1)
                    {
                        answer[i, j] = array[count++];
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }
            // end
            return answer;
        }
        public void Task8(int[,] matrix)
        {
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for(int j = 0; j < n; j++)
            {
                int max = int.MinValue;
                int count1 = 0;
                int count2 = 0;
                int iMax = 0;
                int jMax = 0;
                for(int i = 0; i < m; i++)
                {
                    if(matrix[i, j] > 0)
                    {
                        count1++;
                    }
                    if(matrix[i, j] < 0)
                    {
                        count2++;
                    }
                    if(matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        iMax = i;
                        jMax = j;
                    }
                }
                if(count1 > count2)
                {
                    matrix[iMax, jMax] = 0;
                }
                if(count2 > count1)
                {
                    matrix[iMax, jMax] = iMax;
                }
            }
            // end
        }
        public void Task9(int[,] matrix)
        {
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int m0 = 0;
            int n0 = 0;
            if(m != n)
            {
                return;
            }
            for(int i = 0; i < m * m; i++)
            {
                m0 = i / n;
                n0 = i % n;
                if(m0 == 0 || m0 == m - 1 || n0 == 0 || n0 == n - 1)
                {
                    matrix[m0, n0] = 0;
                }
                
            }
            // end
        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;
            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m != n)
            {
                return (A, B);
            }
            int countA = 0;
            int countB = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                    {
                        countA++;
                    }
                    if (i > j)
                    {
                        countB++;
                    }
                }
            }
            A = new int[countA];
            B = new int[countB];
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i)
                    {
                        A[count1++] = matrix[i, j];
                    }
                    else if (j < i)
                    {
                        B[count2++] = matrix[i, j];
                    }
                }
            }
            // end
            return (A, B);
        }
        public void Task11(int[,] matrix)
        {
            // code here
            //int m = matrix.GetLength(0);
            //int n = matrix.GetLength(1);
            //for(int j = 0; j < n; j++)
            //{
            //    for(int i = 0; i < m - 1; i++)
            //    {
            //        if(j % 2 == 0)
            //        {
            //            if (matrix[i, j] < matrix[i + 1, j])
            //            {
            //                (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
            //            }
            //        }
            //        else
            //        {
            //            if (matrix[i, j] > matrix[i + 1, j])
            //            {
            //                (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
            //            }
            //        }
            //    }
            //}
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++) 
            {
                int i = 1;
                while (i < m) 
                {
                    if (j % 2 == 0) 
                    {
                        if (i == 0 || matrix[i, j] <= matrix[i - 1, j])
                        {
                            i++; 
                        }
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            i--;
                        }
                    }
                    else
                    {
                        if (i == 0 || matrix[i, j] >= matrix[i - 1, j])
                        {
                            i++; 
                        }
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            i--;
                        }
                    }
                }
            }
            // end
        }
        public void Task12(int[][] array)
        {
            // code here
            int m = array.Length;
            int[] sum = new int[m];
            for (int i = 0; i < m; i++)
            {
                sum[i] = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j];
                }
            }
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < m - i - 1; j++)
                {
                    if (array[j].Length < array[j + 1].Length ||
                        (array[j].Length == array[j + 1].Length && sum[j] < sum[j + 1]))
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                    }
                }
            }
            // end
        }
    }
}
