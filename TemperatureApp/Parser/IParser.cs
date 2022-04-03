using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureApp.Parser
{
    public interface IParser<T>
    {
        public T ParseInput(byte[] rawInput);
    }
}
