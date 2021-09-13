using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ZxDxf
{
    internal class Reader 
    {
        private readonly StreamReader _sr;
        private int num;

        public Reader(string filePath)
        {
            _sr = new StreamReader(filePath);
        }
        
        public void Dispose()
        {
            _sr?.Dispose();
        }

        public bool Next()
        {
            if (Current.Value == "EOF" || _sr.EndOfStream)
            {
                return false;
            }

            Current = new KeyValuePair<int, string>
            (
                 Convert.ToInt32(_sr.ReadLine()),
                 _sr.ReadLine()
            );

            num += 2;

            return true;
        }
        
        public KeyValuePair<int, string> Current { get; private set; }        
    }
}
