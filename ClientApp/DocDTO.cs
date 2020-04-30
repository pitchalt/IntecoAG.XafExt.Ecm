using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

namespace WebApplication1.Controllers
{
    public class DocDTO
    {
        //public byte[] content { get; set; }
        //public Dictionary<String, string> Properties { get; set; }
        public string FileName { get; set; }
        public String DocContentType { get; set; }
        public long Id { get; set; }
        //public string[] properties { get; set; }
        public String cmisaction { get; set; }
    }
}
