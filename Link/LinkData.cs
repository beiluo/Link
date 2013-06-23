using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Link
{
    class LinkData
    {
        public List<List<int>> buildmatrix(int x, int y)
        {
            int key = (int)(x * y / 2);
            List<List<int>> res = new List<List<int>>();
            List<int> arr = new List<int>();
            Random r = new Random(10);
            for (var i = 0; i < x * y / 2; i++)
            {
                arr.Add(r.Next(1, 10));
            }
            for (var i = 0; i < (int)arr.Count / 2; i++)
            {
                arr[arr.Count - 1 - i] = arr[i];
            }
            arr = arr.Concat(arr).ToList();
            int k = 0;
            for (var i = 0; i < x + 2; i++)
            {
                var m = new List<int>();
                for (var j = 0; j < y + 2; j++)
                {
                    if (i == 0 || i == x + 1)
                    {
                        m.Add(0);
                    }
                    else if (j == 0 || j == y + 1)
                    {
                        m.Add(0);
                    }
                    else
                    {
                        m.Add(arr[k]);
                        k++;
                    }
                }
                res.Add(m);
            }
            return res;
        }
    }
}
