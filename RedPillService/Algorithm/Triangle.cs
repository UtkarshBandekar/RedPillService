
namespace RedPillService.Algorithm
{
    public class Triangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public TriangleType Type
        {
            get
            {
                // There should also be a side length check
                if (Height <= 0 || Width <= 0 || Length <= 0)
                {
                    return TriangleType.Error;
                }

                //if (((b + c) < Height) || ((Height + c) < Width) || ((Height + Width) < c))
                //{
                //    return TriangleType.Error;

                //}

                if (Height == Width && Height == Length)
                {
                    return TriangleType.Equilateral;
                }
                else if (Height == Width || Height == Length || Width == Length)
                {
                    return TriangleType.Isosceles;
                }
                else
                {
                    return TriangleType.Scalene;
                }
            }
        }
    }
}