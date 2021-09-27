using EasyModbus;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyModbusHelper
{
    public class ModbusHelper : IModbusHelper
    {
        private ModbusClient _client;
        private RegisterOrder _registerOrder = RegisterOrder.LittleEndianByteSwap;
        private ModbusClient.RegisterOrder _clientRegisterOrder = ModbusClient.RegisterOrder.LowHigh;

        public bool Connect(string ip, int port = 502)
        {
            _client = new ModbusClient(ip, port);
            _client.Connect();
            return _client.Connected;
        }

        public RegisterOrder RegisterOrder
        {
            get => _registerOrder;
            set
            {
                _registerOrder = value;
                switch (_registerOrder)
                {
                    case RegisterOrder.LittleEndianByteSwap:
                    case RegisterOrder.LittleEndian:
                        _clientRegisterOrder = ModbusClient.RegisterOrder.LowHigh;
                        break;
                    case RegisterOrder.BigEndianByteSwap:
                    case RegisterOrder.BigEndian:
                        _clientRegisterOrder = ModbusClient.RegisterOrder.HighLow;
                        break;
                }
            }
        }

        public void Write(int address, bool value)
        {
            _client.WriteSingleCoil(address, value);
        }

        public void Write(int startAddress, IEnumerable<bool> values)
        {
            _client.WriteMultipleCoils(startAddress, values.ToArray());
        }

        public void Write(int address, short value)
        {
            _client.WriteSingleRegister(address, value);
        }

        public void Write(int startAddress, IEnumerable<short> values)
        {
            WriteRegisters(startAddress, values.Select(Convert.ToInt32).ToArray());
        }

        public void Write(int address, ushort value)
        {
            Write(address, (short)value);
        }

        public void Write(int startAddress, IEnumerable<ushort> values)
        {
            Write(startAddress, values.Select(Convert.ToInt16).ToArray());
        }

        public void Write(int address, int value)
        {
            var registers = ModbusClient.ConvertIntToRegisters(value, _clientRegisterOrder);
            _client.WriteMultipleRegisters(address, registers);
        }

        public void Write(int startAddress, IEnumerable<int> values)
        {
            var registers = values.Aggregate(new List<int>(), (list, value) =>
            {
                list.AddRange(ModbusClient.ConvertIntToRegisters(value, _clientRegisterOrder));
                return list;
            });

            WriteRegisters(startAddress, registers);
        }

        public void Write(int address, uint value)
        {
            Write(address, (int)value);
        }

        public void Write(int startAddress, IEnumerable<uint> values)
        {
            Write(startAddress, values.Select(x => (int)x));
        }

        public void Write(int address, long value)
        {
            var registers = ModbusClient.ConvertLongToRegisters(value, _clientRegisterOrder);
            _client.WriteMultipleRegisters(address, registers);
        }

        public void Write(int startAddress, IEnumerable<long> values)
        {
            var registers = values.Aggregate(new List<int>(), (list, value) =>
            {
                list.AddRange(ModbusClient.ConvertLongToRegisters(value, _clientRegisterOrder));
                return list;
            });

            WriteRegisters(startAddress, registers);
        }

        public void Write(int address, ulong value)
        {
            Write(address, (long)value);
        }

        public void Write(int startAddress, IEnumerable<ulong> values)
        {
            Write(startAddress, values.Select(x => (long)x));
        }

        public void Write(int address, float value)
        {
            var registers = ModbusClient.ConvertFloatToRegisters(value, _clientRegisterOrder);
            _client.WriteMultipleRegisters(address, registers);
        }

        public void Write(int startAddress, IEnumerable<float> values)
        {
            var registers = values.Aggregate(new List<int>(), (list, value) =>
            {
                list.AddRange(ModbusClient.ConvertFloatToRegisters(value, _clientRegisterOrder));
                return list;
            });

            WriteRegisters(startAddress, registers);
        }

        public void Write(int address, double value)
        {
            var registers = ModbusClient.ConvertDoubleToRegisters(value, _clientRegisterOrder);
            _client.WriteMultipleRegisters(address, registers);
        }

        public void Write(int startAddress, IEnumerable<double> values)
        {
            var registers = values.Aggregate(new List<int>(), (list, value) =>
            {
                list.AddRange(ModbusClient.ConvertDoubleToRegisters(value, _clientRegisterOrder));
                return list;
            });

            WriteRegisters(startAddress, registers);
        }

        public void Write(int address, string value)
        {
            var registers = ModbusClient.ConvertStringToRegisters(value);
            WriteRegisters(address, registers);
        }

        //public T Read<T>(int address)
        //{
        //    throw new NotImplementedException();
        //}

        //public T[] Read<T>(int startAddress, int length)
        //{
        //    throw new NotImplementedException();
        //}

        public bool ReadBool(int address)
        {
            var value = _client.ReadCoils(address, 1)[0];
            return value;
        }

        public List<bool> ReadBool(int startAddress, int length)
        {
            var values = _client.ReadCoils(startAddress, length);
            return values.ToList();
        }

        public short ReadShort(int address)
        {
            var value = _client.ReadHoldingRegisters(address, 1)[0];
            return (short)value;
        }

        public List<short> ReadShort(int startAddress, int length)
        {
            var values = ReadRegisters(startAddress, length);
            return values.Select(x => (short)x).ToList();
        }

        public ushort ReadUShort(int address)
        {
            var value = _client.ReadHoldingRegisters(address, 1)[0];
            return (ushort)value;
        }

        public List<ushort> ReadUShort(int startAddress, int length)
        {
            var values = ReadRegisters(startAddress, length);
            return values.Select(x => (ushort)x).ToList();
        }

        public int ReadInt(int address)
        {
            var registers = _client.ReadHoldingRegisters(address, 2);
            return ModbusClient.ConvertRegistersToInt(registers, _clientRegisterOrder);
        }

        public List<int> ReadInt(int startAddress, int length)
        {
            var registers = ReadRegisters(startAddress, length * 2);
            var values = new List<int>();

            for (var i = 0; i < registers.Length; i += 2)
            {
                values.Add(ModbusClient.ConvertRegistersToInt(registers.Skip(i).Take(2).ToArray(), _clientRegisterOrder));
            }

            return values;
        }

        public uint ReadUInt(int address)
        {
            return (uint)ReadInt(address);
        }

        public List<uint> ReadUInt(int startAddress, int length)
        {
            return ReadInt(startAddress, length).Select(x => (uint)x).ToList();
        }

        public long ReadLong(int address)
        {
            var registers = _client.ReadHoldingRegisters(address, 4);
            return ModbusClient.ConvertRegistersToLong(registers, _clientRegisterOrder);
        }

        public List<long> ReadLong(int startAddress, int length)
        {
            var registers = ReadRegisters(startAddress, length * 4);
            var values = new List<long>();

            for (var i = 0; i < registers.Length; i += 4)
            {
                values.Add(ModbusClient.ConvertRegistersToLong(registers.Skip(i).Take(4).ToArray(), _clientRegisterOrder));
            }

            return values;
        }

        public ulong ReadULong(int address)
        {
            return (ulong)ReadLong(address);
        }

        public List<ulong> ReadULong(int startAddress, int length)
        {
            return ReadLong(startAddress, length).Select(x => (ulong)x).ToList();
        }

        public float ReadFloat(int address)
        {
            var registers = _client.ReadHoldingRegisters(address, 2);
            return ModbusClient.ConvertRegistersToFloat(registers, _clientRegisterOrder);
        }

        public List<float> ReadFloat(int startAddress, int length)
        {
            var registers = ReadRegisters(startAddress, length * 2);
            var values = new List<float>();

            for (var i = 0; i < registers.Length; i += 2)
            {
                values.Add(ModbusClient.ConvertRegistersToFloat(registers.Skip(i).Take(2).ToArray(), _clientRegisterOrder));
            }

            return values;
        }

        public double ReadDouble(int address)
        {
            var registers = _client.ReadHoldingRegisters(address, 4);
            return ModbusClient.ConvertRegistersToDouble(registers, _clientRegisterOrder);
        }

        public List<double> ReadDouble(int startAddress, int length)
        {
            var registers = ReadRegisters(startAddress, length * 4);
            var values = new List<double>();

            for (var i = 0; i < registers.Length; i += 4)
            {
                values.Add(ModbusClient.ConvertRegistersToDouble(registers.Skip(i).Take(4).ToArray(), _clientRegisterOrder));
            }

            return values;
        }

        public string ReadString(int startAddress, int length)
        {
            var l = length / 2 + length % 2;
            var registers = ReadRegisters(startAddress, l);
            var value = ModbusClient.ConvertRegistersToString(registers, 0, l * 2);

            if (length % 2 != 0 && value.EndsWith("\0"))
            {
                value = value.Remove(value.Length - 1);
            }

            return value;
        }

        private void WriteRegisters(int startingAddress, IEnumerable<int> values)
        {
            while (values.Any())
            {
                _client.WriteMultipleRegisters(startingAddress, values.Take(120).ToArray());
                startingAddress += 120;
                values = values.Skip(120).ToArray();
            }
        }

        private int[] ReadRegisters(int startingAddress, int quantity)
        {
            var data = new List<int>();

            while (quantity > 0)
            {
                var length = quantity > 120 ? 120 : quantity;

                data.AddRange(_client.ReadHoldingRegisters(startingAddress, length));
                startingAddress += length;
                quantity -= length;
            }

            return data.ToArray();
        }
    }
}
