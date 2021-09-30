
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Helper
{
    public class JsonPatchUserRequestExample : IExamplesProvider<Operation[]>
    {
        public Operation[] GetExamples()
        {
            return new[]
            {
            new Operation
            {
                Op = "replace",
                Path = "/name",
                    Value = "Gordon"
            },
            new Operation
            {
                Op = "replace",
                Path = "/surname",
                    Value = "Freeman"
            }
        };
        }
    }
}
