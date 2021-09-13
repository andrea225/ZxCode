using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ZxDxf.Entities;
using ZxDxf.Tables;

namespace ZxDxf
{
    public sealed class DxfDocument
    {
        public List<Layer> Layers { get; set; }
        public List<Line> Lines { get; set; }
        public List<LwPolyline> LwPolylines { get; set; }
        public List<Point> Points { get; set; }

        private Reader _reader;

        public DxfDocument()
        {
            Layers = new List<Layer>();
            Lines = new List<Line>();
            LwPolylines = new List<LwPolyline>();
            Points = new List<Point>();
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            Clear();

            _reader = new Reader(filePath);
            try
            {
                Read();
            }
            finally
            {
                _reader.Dispose();
            }
        }

        private void Clear()
        {
            Layers.Clear();
            Lines.Clear();
            LwPolylines.Clear();
            Points.Clear();
        }

        private void Read()
        {
            while (_reader.Next())
            {
                var current = _reader.Current;

                switch (current.Value)
                {
                    //case "SECTION":
                    //    break;
                    case "TABLES":
                        ReadTables();
                        break;
                    case "ENTITIES":
                        ReadEntities();
                        break;
                }
            }
        }

        private void ReadTables()
        {
            while (_reader.Next())
            {
                var current = _reader.Current;
                switch (current.Value)
                {
                    case "LAYER":
                        ReadLayers();
                        break;
                    case "ENDSEC":
                        return;
                }
            }
        }

        private void ReadLayers()
        {
            _reader.Next();

            while (true)
            {
                var current = _reader.Current;

                switch (current.Value)
                {
                    case "LAYER":
                        ReadLayer();
                        break;
                    case "ENDTAB":
                        return;
                    default:
                        _reader.Next();
                        break;
                }

            }
        }

        private void ReadLayer()
        {
            var layer = new Layer();

            while (_reader.Next())
            {
                var current = _reader.Current;
                switch (current.Key)
                {
                    case 0:
                        Layers.Add(layer);
                        return;
                    case 2:
                        layer.Name = current.Value;
                        break;
                    case 62:
                        layer.AciColor = new AciColor(Math.Abs(Convert.ToInt32(current.Value)));
                        break;
                    case 370:
                        layer.LineWeight = (LineWeight)Convert.ToInt32(current.Value);
                        break;
                }
            }
        }

        private void ReadEntities()
        {
            while (true)
            {
                var current = _reader.Current;

                switch (current.Value)
                {
                    case "LWPOLYLINE":
                        ReadLwPolyline();
                        break;
                    case "LINE":
                        ReadLine();
                        break;
                    case "POINT":
                        ReadPoint();
                        break;
                    case "ENDSEC":
                        return;
                    default:
                        _reader.Next();
                        break;
                }
            }
        }

        private void ReadCommonEntityProperty(KeyValuePair<int, string> current, EntityBase entity)
        {
            switch (current.Key)
            {
                case 8:
                    entity.Layer = Layers.Single(x => x.Name == current.Value);
                    break;
                case 62:
                    entity.AciColor = new AciColor(Convert.ToInt32(current.Value));
                    break;
                case 370:
                    entity.LineWeight = (LineWeight)Convert.ToInt32(current.Value);
                    break;
            }
        }

        private void ReadLine()
        {
            var line = new Line();

            while (_reader.Next())
            {
                var current = _reader.Current;

                switch (current.Key)
                {
                    case 0:
                        Lines.Add(line);
                        return;
                    case 10:
                        line.StartPoint.X = Convert.ToDouble(current.Value);
                        break;
                    case 20:
                        line.StartPoint.Y = Convert.ToDouble(current.Value);
                        break;
                    case 11:
                        line.EndPoint.X = Convert.ToDouble(current.Value);
                        break;
                    case 21:
                        line.EndPoint.Y = Convert.ToDouble(current.Value);
                        break;
                    case 39:
                        line.Thickness = Convert.ToDouble(current.Value);
                        break;
                    default:
                        ReadCommonEntityProperty(current, line);
                        break;
                }
            }
        }

        private void ReadLwPolyline()
        {
            var lwPolyline = new LwPolyline();
            var vertex = new Vertex();

            while (_reader.Next())
            {
                var current = _reader.Current;

                switch (current.Key)
                {
                    case 0:
                        LwPolylines.Add(lwPolyline);
                        return;
                    case 10:
                        vertex = new Vertex { X = Convert.ToDouble(current.Value) };
                        break;
                    case 20:
                        vertex.Y = Convert.ToDouble(current.Value);
                        lwPolyline.Vertices.Add(vertex);
                        break;
                    case 39:
                        lwPolyline.Thickness = Convert.ToDouble(current.Value);
                        break;
                    case 70:
                        lwPolyline.IsClosed = Convert.ToInt32(current.Value) == 1;
                        break;
                    default:
                        ReadCommonEntityProperty(current, lwPolyline);
                        break;
                }
            }
        }

        private void ReadPoint()
        {
            var point = new Point();

            while (_reader.Next())
            {
                var current = _reader.Current;

                switch (current.Key)
                {
                    case 0:
                        Points.Add(point);
                        return;
                    case 10:
                        point.Vertex = new Vertex
                        {
                            X = Convert.ToDouble(current.Value)
                        };

                        break;
                    case 20:
                        point.Vertex.Y = Convert.ToDouble(current.Value);
                        break;
                    case 39:
                        point.Thickness = Convert.ToDouble(current.Value);
                        break;
                    default:
                        ReadCommonEntityProperty(current, point);
                        break;
                }
            }
        }
    }
}
