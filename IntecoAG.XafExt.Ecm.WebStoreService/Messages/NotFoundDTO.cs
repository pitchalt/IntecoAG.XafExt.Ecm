﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntecoAG.XafExt.Ecm.WebStoreService.Messages
{
    public class NotFoundDTO:ErrorDTO
    {
        public NotFoundDTO()
        {
            Reason = "Объект не найден";
            CodeResult = "404";
        }
    }
}
