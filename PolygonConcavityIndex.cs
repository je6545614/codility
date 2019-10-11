using System;
using System.Linq;

class Solution {
    
    public class Vector
    {
        #region Fields

        private readonly string name;

        private bool isNomrmalised;

        private double x;

        private double y;

        #endregion

        #region Constructors

        public Vector(double x, double y, string name)
        {
            this.name = name;
            this.x = x;
            this.y = y;

            isNomrmalised = Magnitude.CompareTo(1) == 0;
        }

        public Vector(double x, double y)
            : this(x, y, "V")
        {
        }

        public Vector(Point2D tail, Point2D head, string name)
            : this(head.x - tail.x, head.y - tail.y, name)
        {
        }

        public Vector(Point2D tail, Point2D head)
            : this(tail, head, "V")
        {
        }

        #endregion

        #region Public Properties

        public double X
        {
            get
            {
                return x;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }

        public double Direction
        {
            get
            {
                return GetDirection();
            }
        }

        public double Magnitude
        {
            get
            {
                return GetMagnitude();
            }
        }

        public bool IsNormalised
        {
            get
            {
                return isNomrmalised;
            }
        }

        public Vector UnitVector
        {
            get
            {
                return GetUnitVector();
            }
        }

        #endregion

        #region Public Methods

        public void Normalise()
        {
            if (!isNomrmalised)
            {
                var m = Magnitude;

                x /= m;
                y /= m;   

                isNomrmalised = true;
            }
        }

        public void InvertDirection()
        {
            x *= -1;
            y *= -1;
        }

        public double AngleOfRotationRelativeTo(Vector otherVector, bool clockwise = true, bool degrees = false)
        {
            var v1 = clockwise ? otherVector.UnitVector : UnitVector;
            var v2 = clockwise ? UnitVector : otherVector.UnitVector;

            var angle = Math.Atan2(v2.y, v2.x) - Math.Atan2(v1.y, v1.x);

            if (angle < 0)
            {
                angle += 2 * Math.PI;
            }

            return degrees ? RadToDeg(angle) : angle;
        }

        public override string ToString()
        {
            return string.Format(
                "({0} : Δx = {1,7:N3}, Δy = {2,7:N3}, m = {3:N2}, α = {4,6:N2}°)",
                name, x, y, Magnitude, RadToDeg(Direction));
        }

        #endregion

        #region Methods

        private static double RadToDeg(double angle)
        {
            return angle * 180 / Math.PI;
        }

        private static double DegToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        private double GetDirection()
        {
            var angle = Math.Atan2(y, x);
            return angle >= 0 ? angle : 2 * Math.PI + angle;
        }

        private double GetMagnitude()
        {
            return Math.Sqrt(x * x + y * y);
        }

        private Vector GetUnitVector()
        {
            var m = Magnitude;
            return new Vector(x / m, y / m);
        }

        #endregion
    }
    
    public int solution(Point2D[] A) {
        if (A.Length <= 3)
            {
                return -1;
            }

            var n = A.Length;
            var leftMostIdx = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i].x < A[leftMostIdx].x)
                {
                    leftMostIdx = i;
                }
                else if (A[i].x == A[leftMostIdx].x)
                {
                    if (A[leftMostIdx].x == A[(leftMostIdx + 1) % n].x)
                    {
                        leftMostIdx = i;
                    }
                }
            }

            var leftMost = A[leftMostIdx];
            var next = A[(leftMostIdx + 1) % n];
            var previous = A[(leftMostIdx - 1 + n) % n];

            var previousEdge = new Vector(previous, leftMost);
            var nextEdge = new Vector(leftMost, next);

            var clockwise = previousEdge.AngleOfRotationRelativeTo(nextEdge, clockwise: true, degrees: true) < 180;

            for (int i = 0; i < n; i++)
            {
                var vertex1 = (i + leftMostIdx) % n;
                var vertex2 = (vertex1 + 1) % n;
                var vertex3 = (vertex2 + 1) % n;

                var edge1 = new Vector(A[vertex1], A[vertex2]);
                var edge2 = new Vector(A[vertex2], A[vertex3]);

                var angle = edge1.AngleOfRotationRelativeTo(edge2, clockwise, degrees: true);

                if (angle > 180)
                {
                    return vertex2;
                }
            }

            return -1;
    }
}
