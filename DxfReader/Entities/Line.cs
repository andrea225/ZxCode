namespace ZxDxf.Entities
{
    public class Line : EntityBase
    {
        public Vertex StartPoint { get; set; }
        public Vertex EndPoint { get; set; }
        public double Thickness { get; set; }
    }
}
