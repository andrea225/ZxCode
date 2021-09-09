using System;

namespace ModbusHelperBase
{
    public class ModbusResult
    {
        public bool Success { get; set; } = true;
        public Exception? exception { get; set; }
    }

    public class ModbusResult<T> : ModbusResult
    {
        public ModbusResult()
        {

        }

        public ModbusResult(T content) 
        {
            Content = content;
        }

        public T? Content { get; set; }
    }

    public static class ModbusResultHelper
    {
        public static ModbusResult<T> CopyErrorInfo<T>(ModbusResult resultToCopy)
        {
            return new ModbusResult<T> { Success = false, exception = resultToCopy.exception };
        }
    }
}
