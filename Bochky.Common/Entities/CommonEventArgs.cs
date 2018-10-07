using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochkyLink.Common.Entities
{
    public class CommonEventArgs : EventArgs
    {
        public string Message { get; }

        public CommonEventArgs(string mes)
        {
            this.Message = mes;
        }
    }
}
