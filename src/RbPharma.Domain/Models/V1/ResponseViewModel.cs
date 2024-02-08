using RbPharma.Domain.Enums.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Domain.Models.V1
{
    public class ResponseViewModel
    {
        public string Data { get; set; }
        public List<ErrorViewModel> Errors { get; set; }
        public string Status { get; set; }
    }
}
