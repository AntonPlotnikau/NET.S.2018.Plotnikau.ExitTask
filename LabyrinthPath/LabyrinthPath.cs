using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthPath
{
    public class Point : IEquatable<Point>
    {
        private int x;

        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X => x;
        public int Y => y;

        public bool Equals(Point other)
        {
            if (this.X == other.X && this.Y == other.Y)
                return true;
            return false;
        }
    }

    public class LabyrinthPath
    {
        private Point startPoint;

        private Point endPoint;

        private int[,] labyrinth;

        private Stack<Point> buffer;

        public LabyrinthPath(Point startPoint, Point endPoint, int[,] labyrinth)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.labyrinth = labyrinth;

            buffer = new Stack<Point>();
        }

        public IEnumerable<Point> FindWay()
        {
            FindWay(startPoint.X, startPoint.Y);

            return buffer.Reverse();
        }

        private void FindWay(int i, int j)
        {
            buffer.Push(new Point(i, j));

            if (buffer.Peek().Equals(endPoint))
                return;

            if(CanMoove(i, j))
            {
                Point point = MarkNeighbours(i, j);
                FindWay(point.X, point.Y);
            }
            else
            {
                buffer.Pop();
                Point point = buffer.Peek();
                FindWay(point.X, point.Y);
            }
        }

        private bool CanMoove(int i, int j)
        {
            if(labyrinth[i, j-1] == 0)
            {
                return true;
            }

            if (labyrinth[i-1, j] == 0)
            {
                return true;
            }

            if (labyrinth[i+1, j] == 0)
            {
                return true;
            }

            if (labyrinth[i, j+1] == 0)
            {
                return true;
            }

            return false;
        }

        private Point MarkNeighbours(int i, int j)
        {
            if (labyrinth[i, j - 1] == 0)
            {
                labyrinth[i, j - 1] = 1;
                return new Point(i, j - 1);
            }
            else if (labyrinth[i - 1, j] == 0)
            {
                labyrinth[i - 1, j] = 1;
                return new Point(i - 1, j);
            }
            else if (labyrinth[i + 1, j] == 0)
            {
                labyrinth[i + 1, j] = 1;
                return new Point(i + 1, j);
            }         
            else if (labyrinth[i, j + 1] == 0)
            {
                labyrinth[i, j+1] = 1;
                return new Point(i, j + 1);
            }

            return null;
        }
    }
}
