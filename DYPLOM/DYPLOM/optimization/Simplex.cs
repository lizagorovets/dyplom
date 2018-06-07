using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYPLOM.optimization
{
    class Simplex
    {
        int n;
        int m;
        double[,] table; //симплекс таблица
        double[] c; //симплекс
        List<int> basis; //список базисных переменных
        double[,] basisTable;
        public Simplex(double[,] source, string[] sign)
        {
            int sountSign = sign.GetLength(0);

            m = source.GetLength(0);
            n = source.GetLength(1);
            basis = new List<int>();
            table = new double[m, n + m -1];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (j < n)
                        table[i, j] = source[i, j];
                    else
                        table[i, j] = 0;
                }
            }

            int count = n;
            for (int i = 0; i < m-1; i++)
            {
                if (sign[i].Equals(">=")&count<table.GetLength(1))
                {
                    table[i, count] = -1;
                    count++;
                    //basis.Add(count);
                }
                if (sign[i].Equals("<=")& count < table.GetLength(1))
                {
                    table[i, count] = 1;
                    basis.Add(count);
                    count++;
                }

            }

        }
        public double[,] Calculate(double[] result)
        {

            int mainCol, mainRow; //ведущие столбец и строка
            c = new double[table.GetLength(1)];
            for (int j = 1; j < table.GetLength(1) - 1; j++)
            {
                c[j] = table[table.GetLength(0) - 1, j];

            }
            double[] Delta = countDelta();
              while (!isFoundResult(Delta))
              {
                mainCol = findMainCol(Delta);
                mainRow = findMainRow(mainCol);
                basis[mainRow] = mainCol;
                m = table.GetLength(0);
                n = table.GetLength(1);
                double[,] new_table = new double[m, n];

                for (int j = 0; j < n; j++)
                    new_table[mainRow, j] = table[mainRow, j] / table[mainRow, mainCol];

                for (int i = 0; i < m; i++)
                {
                    if (i == mainRow)
                        continue;

                    for (int j = 0; j < n; j++)
                        new_table[i, j] = table[i, j] - table[i, mainCol] * new_table[mainRow, j];
                }
                table = new_table;
                Delta = countDelta();
            }

            //заносим в result найденные значения X
         /*   for (int i = 0; i < result.Length; i++)
            {
                int k = basis.IndexOf(i + 1);
                if (k != -1)
                    result[i] = table[k, 0];
                else
                    result[i] = 0;
            }*/

            return table;
        }
        private bool isFoundResult(double[] Delta)
        {
            bool result = true;
            for (int j = 0; j < Delta.Count(); j++)
            {
                if (Delta[j] < 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private bool IsItEnd()
        {
            bool flag = true;

            for (int j = 1; j < table.GetLength(1); j++)
            {
                if (table[table.GetLength(0) - 1,j ] < 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private double[] countDelta()
        {
            double[] Delta = new double[table.GetLength(1)];
            for (int j = 0; j < table.GetLength(1); j++)
            {
                for (int i = 0; i < table.GetLength(0)-1; i++)
                {
                    Delta[j] +=table[i, j] * c[basis[i]];
                }
                Delta[j] += -c[j];
            }
            return Delta;
        }


        private int findMainCol(double[] F)
        {
            int mainCol = 1;
            for (int j = 2; j < F.Count(); j++)
                if (Math.Abs(F[j])>Math.Abs( F[mainCol]))
                    mainCol = j;
            return mainCol;
        }

        private int findMainRow(int mainCol)
        {
            int mainRow = 0;

            for (int i = 0; i < table.GetLength(0) - 1; i++)
            {
                if (table[i, mainCol] > 0)
                {
                    mainRow = i;
                    break;
                }
            }
            for (int i = mainRow + 1; i < table.GetLength(0) - 1; i++)
            {
                if ((table[i, mainCol] > 0) && ((table[i, 0] / table[i, mainCol]) < (table[mainRow, 0] / table[mainRow, mainCol])))
                {
                    mainRow = i;
                }
                
            }               

            return mainRow;
        }
    }
}
