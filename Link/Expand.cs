using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Link
{
    public static class Expand
    {
        public static Point Pop(this List<Point> list)
        {
            if (list.Count == 0)
                return null;
            var p = list.LastOrDefault();
            list.Remove(p);
            return p;
        }

        public static int[] Link(this int[] curr, int[] next)
        {
            var cur = curr.ToList();
            for (int i = 0; i < next.Length; i++)
            {
                cur.Add(next[i]);
            }
            return cur.ToArray();
        }

        public static int[] Sort(this int[] curr)
        {
            Random r = new Random(curr.Length);
            for (int i = 0; i < curr.Length; i++)
            {
                var t1 = r.Next(curr.Length);
                var t2=r.Next(curr.Length);
                var temp = curr[t1];
                curr[t1] = curr[t2];
                curr[t2] = temp;
            }
            return curr;
        }

        public static int pop(this int[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var list = arr.ToList();
            var p = list.LastOrDefault();
            list.Remove(p);
            arr = list.ToArray();
            return p;
        }
    }
}
