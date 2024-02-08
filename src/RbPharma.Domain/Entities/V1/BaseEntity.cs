using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RbPharma.Domain.Entities.V1
{
    public abstract class BaseEntity
    {
        public long Id
        {
            get;
            set;
        }
    }
}
