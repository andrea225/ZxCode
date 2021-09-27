using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using ZxDxf;

namespace DxfReaderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = "0、5、9、13、15、18、20、25、30、35、40、50、53、60、70、80、90、100、106、120、140、158、200、211";
            var array = s.Split('、');
            var sb = new StringBuilder();
            foreach (var s1 in array)
            {
                sb.AppendLine($"w{s1}={s1},");
            }

            var f = sb.ToString();
            Debug.WriteLine(f);
        }

        [TestMethod]
        public void TestMethod2()
        {
            IEnumerable<KeyValuePair<int, string>> enumerable = new List<KeyValuePair<int, string>>{ new (1,"aaa"), new (2,"bbb") };
            var e = enumerable.GetEnumerator();

            Debug.WriteLine(e.Current);

            while (e.MoveNext())
            {
                Debug.WriteLine(e.Current);
            }
        }

        [TestMethod]
        public void TestRead()
        {
            var doc = new DxfDocument();
            doc.Load("E:\\work\\IPC\\开口网双线\\Doc\\对比AutoCAD 中望CAD\\章丘书苑上、下弯钩 zw.dxf");
        }
    }
}
