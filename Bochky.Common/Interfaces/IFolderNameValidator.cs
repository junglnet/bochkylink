﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochkyLink.Common.Interfaces
{
    public interface IFolderNameValidator
    {
        bool IsValid(string FolderPath);
    }
}
