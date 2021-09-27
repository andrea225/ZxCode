using System.Collections.Generic;

namespace EasyModbusHelper
{
    public interface IModbusHelper
    {
        bool Connect(string ip, int port = 502);
        public RegisterOrder RegisterOrder { get; set; }

        public void Write(int address, bool value);
        public void Write(int startAddress, IEnumerable<bool> values);

        public void Write(int address, short value);
        public void Write(int startAddress, IEnumerable<short> values);
        public void Write(int address, ushort value);
        public void Write(int startAddress, IEnumerable<ushort> values);

        public void Write(int address, int value);
        public void Write(int startAddress, IEnumerable<int> values);
        public void Write(int address, uint value);
        public void Write(int startAddress, IEnumerable<uint> values);

        public void Write(int address, long value);
        public void Write(int startAddress, IEnumerable<long> values);
        public void Write(int address, ulong value);
        public void Write(int startAddress, IEnumerable<ulong> values);

        public void Write(int address, float value);
        public void Write(int startAddress, IEnumerable<float> values);

        public void Write(int address, double value);
        public void Write(int startAddress, IEnumerable<double> values);

        public void Write(int address, string value);

        //public T Read<T>(int address);
        //public T[] Read<T>(int startAddress, int length);

        public bool ReadBool(int address);
        public List<bool> ReadBool(int startAddress, int length);

        public short ReadShort(int address);
        public List<short> ReadShort(int startAddress, int length);
        public ushort ReadUShort(int address);
        public List<ushort> ReadUShort(int startAddress, int length);

        public int ReadInt(int address);
        public List<int> ReadInt(int startAddress, int length);
        public uint ReadUInt(int address);
        public List<uint> ReadUInt(int startAddress, int length);

        public long ReadLong(int address);
        public List<long> ReadLong(int startAddress, int length);
        public ulong ReadULong(int address);
        public List<ulong> ReadULong(int startAddress, int length);

        public float ReadFloat(int address);
        public List<float> ReadFloat(int startAddress, int length);

        public double ReadDouble(int address);
        public List<double> ReadDouble(int startAddress, int length);

        public string ReadString(int startAddress, int length);

    }
}
