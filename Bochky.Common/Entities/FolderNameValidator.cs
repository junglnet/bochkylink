using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Entities
{
    public class FolderNameValidator : IFolderNameValidator
    {
        public bool IsValid(string FolderPath)
        {
            char[] s = Path.GetInvalidFileNameChars();
            Array.Resize(ref s, s.Length + 1);
            s[s.Length - 1] = ',';
            foreach (char c in s)
            {
                if (FolderPath.IndexOf(c) > 0)
                    return false;
            }
            return true;
        }
    }
}
