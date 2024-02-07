using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RbPharma.Domain.V1.Entities
{
    public abstract class BaseEntity
    {
        public Int64 Id
        {
            get;
            set;
        }
    }
}
