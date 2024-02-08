using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Domain.Models.V1
{
    public class ErrorViewModel
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public ErrorViewModel(string errorCode, string description)
        {
            this.ErrorCode = errorCode;
            this.Description = description;
        }

        public ErrorViewModel()
        {
            
        }
    }
}
