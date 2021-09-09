using FluentModbus;
using ModbusHelperBase;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FluentModbusHelper
{
    public class ModbusHelper : IModbusHelper
    {
        public Endian Endian { get; set; }
        private ModbusClient _client;

        public void Connect(string ip, int port = 502, Endian endian = Endian.Little)
        {
            var endianness = endian == Endian.Little ? ModbusEndianness.LittleEndian : ModbusEndianness.BigEndian;
            _client = new ModbusTcpClient();
            ((ModbusTcpClient)_client).Connect(IPAddress.Parse(ip), endianness);
        }

        public void Disconnect()
        {
            switch (_client)
            {
                case ModbusTcpClient client:
                    client.Disconnect();
                    break;
                case ModbusRtuClient client:
                    client.Close();
                    break;
            }
        }

        public void Dispose()
        {
            Disconnect();
        }

        public T Read<T>(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public T[] Read<T>(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public bool ReadBool(int address, int unitIdentifier = 1)
        {
            _client.WriteMultipleRegisters(1, 100, new[] { 1 });


            _client.ReadInputRegistersAsync(1, 100, 10);
            


            return _client.ReadCoils(unitIdentifier, address, 1)[0] == 1;
        }

        public bool[] ReadBool(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public double ReadDouble(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public double[] ReadDouble(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public float ReadFloat(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public float[] ReadFloat(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public int ReadInt(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public int[] ReadInt(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public long ReadLong(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public long[] ReadLong(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public short ReadShort(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public short[] ReadShort(int address, int quantity, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public string ReadString(int address, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, bool value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, bool[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, short value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, short[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, int value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, int[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, long value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, long[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, float value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, float[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, double value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, double[] values, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public void Write(int address, string value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync(int address, bool value, int unitIdentifier = 1)
        {
            throw new NotImplementedException();
        }
    }
}
