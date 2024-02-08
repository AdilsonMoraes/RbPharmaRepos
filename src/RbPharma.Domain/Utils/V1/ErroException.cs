using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Domain.Utils.V1
{
    public class ErroException : Exception
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public ErroException(string errorCode, string description)
        {
            ErrorCode = errorCode;
            Description = description;
        }
    }
}
