using ZxDxf.Tables;

namespace ZxDxf.Entities
{
    public abstract class EntityBase
    {
        public Layer Layer { get; set; }
        public LineWeight LineWeight { get; set; }
        public AciColor AciColor { get; set; }
    }
}
