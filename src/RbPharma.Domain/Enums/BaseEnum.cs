using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbPharma.Domain.Enums
{
    public class BaseEnum<T, Y> where T : BaseEnum<T, Y>
    {
        public int ErrorCod { get; protected set; }
        public Y Value { get; protected set; }

        protected BaseEnum(int errorCod, Y value)
        {
            ErrorCod = errorCod;
            Value = value;
        }

        public override string ToString()
        {
            return $"{ErrorCod}|{Value}";
        }
    }
}
