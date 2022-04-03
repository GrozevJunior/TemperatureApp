using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureApp.Handler
{
    public interface IHandler<T>
    {
        void Handle(T model);
    }
}
