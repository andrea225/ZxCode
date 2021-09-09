using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ZxDxf
{
    internal class Reader : IEnumerator<KeyValuePair<int,string>>
    {
        private readonly StreamReader _sr;

        public Reader(string filePath)
        {
            _sr = new StreamReader(filePath);
        }

        public Pair Next()
        {
            var pair = new Pair
            {
                Code = Convert.ToInt32(_sr.ReadLine()),
                Value = _sr.ReadLine()
            };

            return pair;
        }


        public void Dispose()
        {
            _sr?.Dispose();
        }

        public bool MoveNext()
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

            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<int, string> Current { get; private set; }

        object IEnumerator.Current => Current;
    }
}
