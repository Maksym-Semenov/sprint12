namespace Triangles.Models
{
    public class Triangle
    {
        private double side1;
        private double side2;
        private double side3;

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
