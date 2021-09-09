using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModbusHelperBase
{
    public interface IModbusHelper : IDisposable
    {
        public Endian Endian { get; set; }

        public void Connect(string ip, int port = 502, Endian Endian = Endian.Little);
        public void Disconnect();

        #region Write

        #region bool
        public void Write(int address, bool value, int unitIdentifier = 1);
        public Task WriteAsync(int address, bool value, int unitIdentifier = 1);
        public void Write(int address, bool[] values, int unitIdentifier = 1);
        #endregion

        #region short
        public void Write(int address, short value, int unitIdentifier = 1);
        public void Write(int address, short[] values, int unitIdentifier = 1);
        public void Write(int address, ushort value, int unitIdentifier = 1)
        {
            Write(address, Convert.ToInt16(value), unitIdentifier);
        }

        public void Write(int address, ushort[] values, int unitIdentifier = 1)
        {
            var v = values.Select(x => Convert.ToInt16(x));
            Write(address, v.ToArray(), unitIdentifier);
        }
        #endregion

        #region int
        public void Write(int address, int value, int unitIdentifier = 1);
        public void Write(int address, int[] values, int unitIdentifier = 1);
        public void Write(int address, uint value, int unitIdentifier = 1)
        {
            Write(address, Convert.ToInt32(value), unitIdentifier);
        }

        public void Write(int address, uint[] values, int unitIdentifier = 1)
        {
            var v = values.Select(x => Convert.ToInt32(x));
            Write(address, v.ToArray(), unitIdentifier);
        }
        #endregion

        #region long
        public void Write(int address, long value, int unitIdentifier = 1);
        public void Write(int address, long[] values, int unitIdentifier = 1);
        public void Write(int address, ulong value, int unitIdentifier = 1)
        {
            Write(address, Convert.ToInt64(value), unitIdentifier);
        }

        public void Write(int address, ulong[] values, int unitIdentifier = 1)
        {
            var v = values.Select(x => Convert.ToInt64(x));
            Write(address, v.ToArray(), unitIdentifier);
        }
        #endregion

        #region float
        public void Write(int address, float value, int unitIdentifier = 1);
        public void Write(int address, float[] values, int unitIdentifier = 1);
        #endregion

        #region double
        public void Write(int address, double value, int unitIdentifier = 1);
        public void Write(int address, double[] values, int unitIdentifier = 1);
        #endregion

        #region string
        public void Write(int address, string value, int unitIdentifier = 1);
        #endregion

        #endregion

        #region Read

        public T Read<T>(int address, int unitIdentifier = 1);
        public T[] Read<T>(int address, int quantity, int unitIdentifier = 1);

        #region bool
        public bool ReadBool(int address, int unitIdentifier = 1);
        public bool[] ReadBool(int address, int quantity, int unitIdentifier = 1);
        #endregion

        #region short
        public short ReadShort(int address, int unitIdentifier = 1);
        public short[] ReadShort(int address, int quantity, int unitIdentifier = 1);
        public ushort ReadUShort(int address, int unitIdentifier = 1)
        {
            var result = ReadShort(address, unitIdentifier);
            return Convert.ToUInt16(result);
        }

        public ushort[] ReadUShort(int address, int quantity, int unitIdentifier = 1)
        {
            var result = ReadUShort(address, quantity, unitIdentifier);
            return result.Select(x => Convert.ToUInt16(x)).ToArray();
        }
        #endregion

        #region int
        public int ReadInt(int address, int unitIdentifier = 1);
        public int[] ReadInt(int address, int quantity, int unitIdentifier = 1);
        public uint ReadUInt(int address, int unitIdentifier = 1)
        {
            var result = ReadInt(address, unitIdentifier);
            return Convert.ToUInt32(result);
        }
        public uint[] ReadUInt(int address, int quantity, int unitIdentifier = 1)
        {
            var result = ReadInt(address, quantity, unitIdentifier);
            return result.Select(x => Convert.ToUInt32(x)).ToArray();
        }
        #endregion

        #region long
        public long ReadLong(int address, int unitIdentifier = 1);
        public long[] ReadLong(int address, int quantity, int unitIdentifier = 1);
        public ulong ReadULong(int address, int unitIdentifier = 1)
        {
            var result = ReadLong(address, unitIdentifier);
            return Convert.ToUInt64(result);
        }
        public ulong[] ReadULong(int address, int quantity, int unitIdentifier = 1)
        {
            var result = ReadLong(address, quantity, unitIdentifier);
            return result.Select(x => Convert.ToUInt64(x)).ToArray();
        }
        #endregion

        #region
        public float ReadFloat(int address, int unitIdentifier = 1);
        public float[] ReadFloat(int address, int quantity, int unitIdentifier = 1);
        #endregion

        #region double
        public double ReadDouble(int address, int unitIdentifier = 1);
        public double[] ReadDouble(int address, int quantity, int unitIdentifier = 1);
        #endregion

        #region string
        public string ReadString(int address, int unitIdentifier = 1);
        #endregion

        #endregion
    }
}
