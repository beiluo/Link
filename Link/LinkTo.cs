using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Link
{
    public class LinkTo
    {
        List<List<Point>> orbit = new List<List<Point>>();
        Point src, dest;
        int[][] map;
        int index = 0;
        public LinkTo(Point src, Point dest, int[][] map)
        {
            this.src = src;
            this.dest = dest;
            this.map = map;
        }

        public Lines WalkMan()
        {
            while (true)
            {
                if (orbit.Count == 0) return new Lines();
                if (map[src.x][src.y] != map[dest.x][dest.y]) return new Lines();//如果2个选中块不相同
                if (map[src.x][src.y] == map[dest.x][dest.y] && map[src.x][src.y] == 0) return new Lines();//如果2个选中块都为已经消除的
                if (src.x == dest.x && src.y == dest.y) return new Lines();//如果2次选择为同一个块
                var cur = Current();
                var next = Neighbor();
                if (Turning(orbit[index]) > 2)
                {
                    orbit.RemoveAt(0);
                    continue;
                }
                //判断当前点与目标点的距离
                if (Adjacent(cur, dest))
                {
                    orbit[index].Add(dest);
                    if (Turning(orbit[index]) < 3)
                        return new Lines(orbit[index]);
                    else
                    {
                        orbit.RemoveAt(0);
                        continue;
                    }
                }

                if (next.Count > 0)
                {
                    orbit[index].Add(next.Pop());
                    Division(next);
                }
                else
                {
                    orbit.RemoveAt(0);
                }
            }

        }

        private void Division(List<Point> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var cur = list[i];
                var prelocus = orbit[index];
                prelocus.Pop();
                prelocus.Add(cur);
                orbit.Insert(1, prelocus);
            }
        }

        private bool Adjacent(Point cur, Point dest)
        {
            if (Math.Abs(cur.x - dest.x) + Math.Abs(cur.y - dest.y) == 1)
                return true;
            return false;
        }

        private List<Point> Neighbor()
        {
            var cur = Current();
            var list = new List<Point>();
            //同行--右
            if (cur.x + 1 <= map[0].Count() - 1 && map[cur.x + 1][cur.y] == 0 && !orbit[index].Contains(new Point { x = cur.x + 1, y = cur.y }))
            {
                list.Add(new Point { x = cur.x + 1, y = cur.y });
            }
            //同行--左
            if (cur.x - 1 >= 0 && map[cur.x - 1][cur.y] == 0 && orbit[index].Contains(new Point { x = cur.x - 1, y = cur.y }))
            {
                list.Add(new Point { x = cur.x - 1, y = cur.y });
            }
            //同列--上
            if (cur.y + 1 <= map.Count() - 1 && map[cur.x][cur.y + 1] == 0 && orbit[index].Contains(new Point { x = cur.x, y = cur.y + 1 }))
            {
                list.Add(new Point { x = cur.x, y = cur.y + 1 });
            }
            //同列--下
            if (cur.y - 1 >= 0 && map[cur.x][cur.y - 1] == 0 && orbit[index].Contains(new Point { x = cur.x, y = cur.y - 1 }))
            {
                list.Add(new Point { x = cur.x, y = cur.y - 1 });
            }
            return Priority(list);
        }

        private List<Point> Priority(List<Point> list)
        {
            var n = list.Count;
            Point tmp;
            bool exchange;
            if (n < 2) return list;
            //冒泡排序
            for (var time = 0; time < n - 1; time++)
            {
                exchange = false;
                for (var i = n - 1; i > time; i--)
                {
                    if (Estimate(list[i]) > Estimate(list[i - 1]))
                    {
                        exchange = true;
                        tmp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = tmp;
                    }
                }
                if (!exchange) break;
            }
            return list;
        }

        private double Estimate(Point point)
        {
            double f, g, h1, h2;
            var locus = orbit[index];
            locus.Add(point);
            g = Turning(locus);
            h1 = 1;
            h2 = Math.Sqrt(Math.Pow(point.x - dest.x, 2) + Math.Pow(point.y - dest.y, 2));
            if (point.x != dest.x && point.y != dest.y)
            {
                h1 = 2;
            }
            f = (g + h1) * 100 + h2 * 0.01;
            return f;
        }

        //计算折点数
        private double Turning(List<Point> arr)
        {
            var turns = new List<char>();
            for (var i = 0; i < arr.Count; i++)
            {
                if (i != arr.Count - 1)
                {
                    if (arr[i].x == arr[i + 1].x)
                    {
                        if (turns.LastOrDefault() != 'y')
                            turns.Add('y');
                    }
                    else if (arr[i].y == arr[i + 1].y)
                    {
                        if (turns.LastOrDefault() != 'x')
                            turns.Add('x');
                    }
                }
            }
            return turns.Count - 1;
        }

        private Point Current()
        {
            return orbit[index].LastOrDefault();
        }
    }
}
