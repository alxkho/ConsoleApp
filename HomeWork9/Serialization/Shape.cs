namespace HomeWork9.Serialization
{
    [Serializable]
    public class Shape
    {
        public Point ShapePoint { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public string Name { get; set; }
        public Shape() { }
        public Shape(Point point, float length, float height, string name)
        {
            ShapePoint = point;
            Length = length;
            Height = height;
            Name = name;
        }
    }
}