using System;
using System.Collections.Generic;
using System.Linq;

using EasyModbus;

using EasyModbusHelper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyModbusHelperTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var values = new List<int> { 1, 2, 3 };

            var registers1 = values.Aggregate(new List<int>(), (list, value) =>
            {
                list.AddRange(ModbusClient.ConvertIntToRegisters(value));
                return list;
            });

            var registers2 = new List<int>();
            foreach (var value in values)
            {
                registers2.AddRange(ModbusClient.ConvertIntToRegisters(value));
            }

            Assert.IsTrue(registers2.SequenceEqual(registers2));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var values = new List<uint> { 1u, 2u, 3u };

            var values1 = values.Select(Convert.ToInt32);
            var values2 = values.Select(x => (int)x);

            Assert.IsTrue(values1.SequenceEqual(values2));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var modbusHelper = new ModbusHelper();
            modbusHelper.Connect("127.0.0.1");

            var values = modbusHelper.ReadInt(0, 3);
            Assert.IsTrue(values.SequenceEqual(new List<int> { 100001, 11000, 2304 }));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var modbusHelper = new ModbusHelper();
            modbusHelper.Connect("127.0.0.1");

            var s = "abcd";

            modbusHelper.Write(0, s);
            var r = modbusHelper.ReadString(0, s.Length);

            Assert.AreEqual(s, r);
        }
    }
}
