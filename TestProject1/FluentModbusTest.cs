using FluentModbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class FluentModbusTest
    {
        [TestMethod]
        public void Test1()
        {
            var client = new ModbusTcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), ModbusEndianness.LittleEndian);

            var values = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                values.Add(i);
            }

            var bytes = new List<byte>();

            foreach (var value in values)
            {
                bytes.AddRange(BitConverter.GetBytes(value));
            }

           
            client.WriteMultipleRegisters((byte)1, (ushort)0, bytes.ToArray());
        }
    }
}
