namespace MainLibrary.Figure
{
    public class Cube : Square
    {
        public Cube(double length) : base(length) 
        {
            Name = "Куб";
        }
        
        public override double GetArea()
        {
            return Length * Length * Length;
        }
    }
}