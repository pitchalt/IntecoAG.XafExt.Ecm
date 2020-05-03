using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Messages
{
    public class ServerErrorDTO: ErrorDTO
    {
        public ServerErrorDTO()
        {
            Reason = "Ошибка сервера";
            CodeResult = "500";
        }
    }
}
