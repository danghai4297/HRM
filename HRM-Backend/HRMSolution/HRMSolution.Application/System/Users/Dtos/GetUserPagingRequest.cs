using HRMSolution.Application.System.Users.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
