﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Oct.Framework.TestWeb.Models
{
    public enum TestEnum
    {
        [Description("OK")]
        Ok=1,
         [Description("buOK")]
        buOk=2
    }
}