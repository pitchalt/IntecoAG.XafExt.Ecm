using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Messages
{
    public class BadRequestDTO:ErrorDTO
    {
        public BadRequestDTO()
        {
            Reason = "Некорректный запрос. Фу таким быть!";
            CodeResult = "400";
        }
    }
}
