using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Exceptions.Handlers
{
    internal class BusinessProblemDetails : ProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Rule violation";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/business";
            Instance = "";
        }
    }
}
