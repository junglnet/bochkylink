using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// UI создания клиентской спецификации
    /// </summary>
    public interface ICreateClientSpecUI
    {
        ISettings Settings { get; }
        ISpecService SpecBusinessLayer { get; }
    }
}
