/***************************************************************************
 *
 *   RunUO                   : May 1, 2002
 *   portions copyright      : (C) The RunUO Software Team
 *   email                   : info@runuo.com
 *   
 *   Angel Island UO Shard   : March 25, 2004
 *   portions copyright      : (C) 2004-2024 Tomasello Software LLC.
 *   email                   : luke@tomasello.com
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

/* Server/Geometry.cs
 * CHANGELOG
 *	8/31/10, Adam
 *		make Point2D serializable
 *	9/01/06 Taran Kain
 *		Added + and - operators to Point3D
 */

namespace Server
{
    [Serializable]
    [Parsable]
    public struct Point2D : IPoint2D
    {
        internal int m_X;
        internal int m_Y;

        public static readonly Point2D Zero = new Point2D(0, 0);

        public Point2D(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }

        public Point2D(IPoint2D p)
            : this(p.X, p.Y)
        {
        }

        public Point2D(IPoint3D p)
            : this(p.X, p.Y)
        {
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", m_X, m_Y);
        }

        public static Point2D Parse(string value)
        {
            int[] tab = Utility.IntParser(value);
            if (tab.Length == 2)
                return new Point2D(tab[0], tab[1]);
            else
                return new Point2D();
        }

        public override bool Equals(object o)
        {
            if (o == null || !(o is IPoint2D)) return false;

            IPoint2D p = (IPoint2D)o;

            return m_X == p.X && m_Y == p.Y;
        }

        public override int GetHashCode()
        {
            return m_X ^ m_Y;
        }

        public static bool operator ==(Point2D l, Point2D r)
        {
            return l.m_X == r.m_X && l.m_Y == r.m_Y;
        }

        public static bool operator !=(Point2D l, Point2D r)
        {
            return l.m_X != r.m_X || l.m_Y != r.m_Y;
        }

        public static bool operator ==(Point2D l, IPoint2D r)
        {
            return l.m_X == r.X && l.m_Y == r.Y;
        }

        public static bool operator !=(Point2D l, IPoint2D r)
        {
            return l.m_X != r.X || l.m_Y != r.Y;
        }

        public static bool operator >(Point2D l, Point2D r)
        {
            return l.m_X > r.m_X && l.m_Y > r.m_Y;
        }

        public static bool operator >(Point2D l, Point3D r)
        {
            return l.m_X > r.m_X && l.m_Y > r.m_Y;
        }

        public static bool operator >(Point2D l, IPoint2D r)
        {
            return l.m_X > r.X && l.m_Y > r.Y;
        }

        public static bool operator <(Point2D l, Point2D r)
        {
            return l.m_X < r.m_X && l.m_Y < r.m_Y;
        }

        public static bool operator <(Point2D l, Point3D r)
        {
            return l.m_X < r.m_X && l.m_Y < r.m_Y;
        }

        public static bool operator <(Point2D l, IPoint2D r)
        {
            return l.m_X < r.X && l.m_Y < r.Y;
        }

        public static bool operator >=(Point2D l, Point2D r)
        {
            return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
        }

        public static bool operator >=(Point2D l, Point3D r)
        {
            return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
        }

        public static bool operator >=(Point2D l, IPoint2D r)
        {
            return l.m_X >= r.X && l.m_Y >= r.Y;
        }

        public static bool operator <=(Point2D l, Point2D r)
        {
            return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
        }

        public static bool operator <=(Point2D l, Point3D r)
        {
            return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
        }

        public static bool operator <=(Point2D l, IPoint2D r)
        {
            return l.m_X <= r.X && l.m_Y <= r.Y;
        }
    }

    [Parsable]
    public struct Point3D : IPoint3D
    {
        internal int m_X;
        internal int m_Y;
        internal int m_Z;

        public static readonly Point3D Zero = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
        }

        public Point3D(IPoint3D p)
            : this(p.X, p.Y, p.Z)
        {
        }

        public Point3D(IPoint2D p, int z)
            : this(p.X, p.Y, z)
        {
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Z
        {
            get
            {
                return m_Z;
            }
            set
            {
                m_Z = value;
            }
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", m_X, m_Y, m_Z);
        }

        public override bool Equals(object o)
        {
            if (o == null || !(o is IPoint3D)) return false;

            IPoint3D p = (IPoint3D)o;

            return m_X == p.X && m_Y == p.Y && m_Z == p.Z;
        }

        public override int GetHashCode()
        {
            return m_X ^ m_Y ^ m_Z;
        }

        public static Point3D Parse(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int[] tab = Utility.IntParser(value);
                if (tab.Length == 3)
                    return new Point3D(Convert.ToInt32(tab[0]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[2]));
                else
                    return new Point3D();
            }
            else
            {
                //Utility.ConsoleOut("Unable to parse Point3D().", ConsoleColor.Red);
                return new Point3D();
            }
        }

        public static bool operator ==(Point3D l, Point3D r)
        {
            return l.m_X == r.m_X && l.m_Y == r.m_Y && l.m_Z == r.m_Z;
        }

        public static bool operator !=(Point3D l, Point3D r)
        {
            return l.m_X != r.m_X || l.m_Y != r.m_Y || l.m_Z != r.m_Z;
        }

        public static bool operator ==(Point3D l, IPoint3D r)
        {
            return l.m_X == r.X && l.m_Y == r.Y && l.m_Z == r.Z;
        }

        public static bool operator !=(Point3D l, IPoint3D r)
        {
            return l.m_X != r.X || l.m_Y != r.Y || l.m_Z != r.Z;
        }

        public static Point3D operator +(Point3D l, Point3D r)
        {
            return new Point3D(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
        }

        public static Point3D operator -(Point3D l, Point3D r)
        {
            return new Point3D(l.X - r.X, l.Y - r.Y, l.Z - r.Z);
        }
    }

    [NoSort]
    [Parsable]
    [PropertyObject]
    public struct Rectangle2D
    {
        private Point2D m_Start;
        private Point2D m_End;

        public Rectangle2D(IPoint2D start, IPoint2D end)
        {
            m_Start = new Point2D(start);
            m_End = new Point2D(end);
        }

        public Rectangle2D(int x, int y, int width, int height)
        {
            m_Start = new Point2D(x, y);
            m_End = new Point2D(x + width, y + height);
        }

        public void Set(int x, int y, int width, int height)
        {
            m_Start = new Point2D(x, y);
            m_End = new Point2D(x + width, y + height);
        }

        public static Rectangle2D Parse(string value)
        {
            int start = value.IndexOf('(');
            int end = value.IndexOf(',', start + 1);

            string param1 = value.Substring(start + 1, end - (start + 1)).Trim();

            start = end;
            end = value.IndexOf(',', start + 1);

            string param2 = value.Substring(start + 1, end - (start + 1)).Trim();

            start = end;
            end = value.IndexOf(',', start + 1);

            string param3 = value.Substring(start + 1, end - (start + 1)).Trim();

            start = end;
            end = value.IndexOf(')', start + 1);

            string param4 = value.Substring(start + 1, end - (start + 1)).Trim();

            return new Rectangle2D(Convert.ToInt32(param1), Convert.ToInt32(param2), Convert.ToInt32(param3), Convert.ToInt32(param4));
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point2D Start
        {
            get
            {
                return m_Start;
            }
            set
            {
                m_Start = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point2D End
        {
            get
            {
                return m_End;
            }
            set
            {
                m_End = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return m_Start.m_X;
            }
            set
            {
                m_Start.m_X = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return m_Start.m_Y;
            }
            set
            {
                m_Start.m_Y = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Width
        {
            get
            {
                return m_End.m_X - m_Start.m_X;
            }
            set
            {
                m_End.m_X = m_Start.m_X + value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Height
        {
            get
            {
                return m_End.m_Y - m_Start.m_Y;
            }
            set
            {
                m_End.m_Y = m_Start.m_Y + value;
            }
        }

        public void MakeHold(Rectangle2D r)
        {
            if (r.m_Start.m_X < m_Start.m_X)
                m_Start.m_X = r.m_Start.m_X;

            if (r.m_Start.m_Y < m_Start.m_Y)
                m_Start.m_Y = r.m_Start.m_Y;

            if (r.m_End.m_X > m_End.m_X)
                m_End.m_X = r.m_End.m_X;

            if (r.m_End.m_Y > m_End.m_Y)
                m_End.m_Y = r.m_End.m_Y;
        }

        public bool Contains(Point3D p)
        {
            return (m_Start.m_X <= p.m_X && m_Start.m_Y <= p.m_Y && m_End.m_X > p.m_X && m_End.m_Y > p.m_Y);
            //return ( m_Start <= p && m_End > p );
        }

        public bool Contains(Point2D p)
        {
            return (m_Start.m_X <= p.m_X && m_Start.m_Y <= p.m_Y && m_End.m_X > p.m_X && m_End.m_Y > p.m_Y);
            //return ( m_Start <= p && m_End > p );
        }

        public bool Contains(IPoint2D p)
        {
            return (m_Start <= p && m_End > p);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})+({2}, {3})", X, Y, Width, Height);
        }
    }

    [NoSort]
    [PropertyObject]
    public struct Rectangle3D
    {
        private Point3D m_Start;
        private Point3D m_End;

        public Rectangle3D(Point3D start, Point3D end)
        {
            m_Start = start;
            m_End = end;
        }

        public Rectangle3D(int x, int y, int z, int width, int height, int depth)
        {
            m_Start = new Point3D(x, y, z);
            m_End = new Point3D(x + width, y + height, z + depth);
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point3D Start
        {
            get
            {
                return m_Start;
            }
            set
            {
                m_Start = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point3D End
        {
            get
            {
                return m_End;
            }
            set
            {
                m_End = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Width
        {
            get
            {
                return m_End.X - m_Start.X;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Height
        {
            get
            {
                return m_End.Y - m_Start.Y;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Depth
        {
            get
            {
                return m_End.Z - m_Start.Z;
            }
        }

        public bool Contains(Point3D p)
        {
            return (p.m_X >= m_Start.m_X)
                && (p.m_X < m_End.m_X)
                && (p.m_Y >= m_Start.m_Y)
                && (p.m_Y < m_End.m_Y)
                && (p.m_Z >= m_Start.m_Z)
                && (p.m_Z < m_End.m_Z);
        }

        public bool Contains(IPoint3D p)
        {
            return (p.X >= m_Start.m_X)
                && (p.X < m_End.m_X)
                && (p.Y >= m_Start.m_Y)
                && (p.Y < m_End.m_Y)
                && (p.Z >= m_Start.m_Z)
                && (p.Z < m_End.m_Z);
        }
    }
}