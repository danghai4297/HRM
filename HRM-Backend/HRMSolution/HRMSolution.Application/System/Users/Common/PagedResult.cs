﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.System.Users.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
