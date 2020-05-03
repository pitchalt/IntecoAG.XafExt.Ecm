using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Messeges
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            Reason = "Неизвестная ошибка";
            CodeResult = "520";
        }
        public String Reason { get; set; }
        public String CodeResult { get; set; }
    }
}
