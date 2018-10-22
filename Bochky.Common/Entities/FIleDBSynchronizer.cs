using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Entities
{
    public class FIleDBSynchronizer : IDBSynchronizer
    {
        string templateDBFilePath;
        string localDBFilePath;

        public FIleDBSynchronizer(string templateDBFilePath, string localDBFilePath)
        {
            this.templateDBFilePath = templateDBFilePath;
            this.localDBFilePath = localDBFilePath;
        }

        public void Sync()
        {
            
            FileInfo templateDBFile = new FileInfo(templateDBFilePath);
            if(templateDBFile.Exists)
            {                
                FileInfo localDBFile = new FileInfo(localDBFilePath);
                if (localDBFile.Exists)
                {                    
                    if (templateDBFile.LastWriteTime != localDBFile.LastWriteTime)
                    {

                        Directory.CreateDirectory(Path.GetDirectoryName(localDBFilePath));
                        templateDBFile.CopyTo(localDBFilePath, true);
                    }

                }
                else
                {                    
                    Directory.CreateDirectory(Path.GetDirectoryName(localDBFilePath));
                    templateDBFile.CopyTo(localDBFilePath, true);
                }
                    

            }
        }
    }
}
