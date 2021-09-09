//using EasyModbus;
//using ModbusHelperBase;
//using System;
//using System.Threading.Tasks;

//namespace EasyModbusHelper
//{
//    public class ModbusHelper : IModbusHelper
//    {
//        private ModbusClient _client = new ModbusClient();
//        public Endian Endian { get; set; }

//        public ModbusResult Connect(string ip, int port = 502)
//        {
//            Disconnect();

//            try
//            {
//                _client.Connect();
//                return new ModbusResult();
//            }
//            catch (Exception e)
//            {
//                return new ModbusResult { Success = false, exception = e };
//            }

//        }

//        public ModbusResult Disconnect()
//        {
//            try
//            {
//                _client?.Disconnect();
//                return new ModbusResult();
//            }
//            catch (Exception e)
//            {
//                return new ModbusResult { Success = false, exception = e };
//            }
//        }

//        public void Dispose()
//        {
//            Disconnect();
//        }

//        public ModbusResult<T> Read<T>(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<T[]> Read<T>(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<bool> ReadBool(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<bool[]> ReadBool(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<double> ReadDouble(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<double[]> ReadDouble(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<float> ReadFloat(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<float[]> ReadFloat(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<int> ReadInt(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<int[]> ReadInt(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<long> ReadLong(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<long[]> ReadLong(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<short> ReadShort(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<short[]> ReadShort(int address, int quantity, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public ModbusResult<string> ReadString(int address, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, bool value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, bool[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, short value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, short[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, int value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, int[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, long value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, long[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, float value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, float[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, double value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, double[] values, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Write(int address, string value, int unitIdentifier = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task WriteAsync(int address, bool value, int unitIdentifier = 1)
//        {
//            await Task.Factory.StartNew(() =>
//            {
//                _client.UnitIdentifier = 1;
//                _client.WriteSingleCoil(address, value);

//            });


//        }

//        private void ChangeUnitIdentifier()
//        {
//            lock (this)
//            {
//                _client.UnitIdentifier = 1;
//            }
//        }
//    }
//}
