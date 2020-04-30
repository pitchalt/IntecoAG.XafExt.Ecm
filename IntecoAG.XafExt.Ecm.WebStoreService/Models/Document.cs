using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Models
{
    public class Document
    {
        public String Name { get; set; }
        public Stream Body { get; set; }
        public String ContentType { get; set; }
    }
}
