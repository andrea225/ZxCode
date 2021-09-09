using System;
using System.Collections.Generic;
using System.IO;

using ZxDxf.Entities;
using ZxDxf.Tables;

namespace ZxDxf
{
    public class DxfDocument
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

        private void Read()
        {
            while (_reader.MoveNext())
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
            while (_reader.MoveNext())
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
            _reader.MoveNext();

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
                        _reader.MoveNext();
                        break;
                }

            }


            //_reader.MoveNext();
            //while (_reader.Current.Value!="LAYER")
            //{
            //    _reader.MoveNext();
            //}

            //while (_reader.Current.Value == "LAYER")
            //{
            //    ReadLayer();
            //}
            
        }

        private void ReadLayer()
        {
            while (_reader.MoveNext())
            {
                switch (_reader.Current.Key)
                {
                    case 0:
                        return;
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
                    case "ENDSEC":
                        return;
                    default:
                        _reader.MoveNext();
                        break;
                }

            } 
        }

        private void ReadLine()
        {
            while (_reader.MoveNext())
            {
                switch (_reader.Current.Key)
                {
                    case 0:
                        return;
                }
            }
        }

        private void ReadLwPolyline()
        {
            while (_reader.MoveNext())
            {
                switch (_reader.Current.Key)
                {
                    case 0:
                        return;
                }
            }
        }
    }
}
