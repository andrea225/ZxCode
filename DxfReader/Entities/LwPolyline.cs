using System.Collections.Generic;

namespace ZxDxf.Entities
{
    public class LwPolyline : EntityBase
    {
        public double Thickness { get; set; }
        public bool IsClosed { get; set; }
        public List<Vertex> Vertices { get; set; }
    }
}
