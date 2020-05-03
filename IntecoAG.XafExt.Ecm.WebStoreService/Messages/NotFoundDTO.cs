using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Messeges
{
    public class NotFoundDTO:ErrorDTO
    {
        public NotFoundDTO()
        {
            Reason = "Объект не найдет";
            CodeResult = "404";
        }
    }
}
