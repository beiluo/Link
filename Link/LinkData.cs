using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Link
{
    class LinkData
    {
        public int[][] buildmatrix(int x, int y)
        {
            int key = (int)(x * y / 2);
            int[][] res = new int[][]{};
            int[] arr = new int[key];
            Random r = new Random(10);
            for (var i = 0; i < x * y / 2; i++)
            {
                arr[i] = r.Next(1, 10);
            }
            for (var i = 0; i < (int)arr.Length / 2; i++)
            {
                arr[arr.Length - 1 - i] = arr[i];
            }
            arr = arr.Link(arr);
            for (var i = 0; i < x + 2; i++)
            {
                res[i] = arr;
                for (var j = 0; j < y + 2; j++)
                {
                    if (i == 0 || i == x + 1)
                    {
                        res[i][j] = 0;
                    }
                    else if (j == 0 || j == y + 1)
                    {
                        res[i][j] = 0;
                    }
                    else
                    {
                        res[i][j] = arr.pop();
                    }
                }
            }
            return res;
        }
    }
}
