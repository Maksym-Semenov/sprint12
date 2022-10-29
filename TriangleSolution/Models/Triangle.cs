namespace Triangles.Models
{
    public class Triangle
    {
        private double side1;
        private double side2;
        private double side3;
        public static bool IsValid(Triangle tr)
        { 
            return tr.Side1 + tr.Side2 >= tr.Side3
                   && tr.Side2 + tr.Side3 >= tr.Side1
                   && tr.Side1 + tr.Side3 >= tr.Side2
                   && tr.Side1 > 0
                   && tr.Side2 > 0
                   && tr.Side3 > 0;
        }
        public Triangle()
        {
        }
        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;           
        }
        public double Side1 
        {
            get { return side1; } 
            set { side1 = value; }
        }
        public double Side2
        {
            get { return side2; }
            set { side2 = value; }
        }
        public double Side3
        {
            get { return side3; }
            set { side3 = value; }
        }
    }
}
