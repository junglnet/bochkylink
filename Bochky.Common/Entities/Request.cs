using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    public class Request
    {
        public Category CurrentCategory { get; set; }
        public Model CurrentModel { get; set; }
        public Folder ClientFolder { get; set; }        
    }
}
