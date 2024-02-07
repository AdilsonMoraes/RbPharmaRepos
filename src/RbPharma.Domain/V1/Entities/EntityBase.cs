using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RbPharma.Domain.V1.Entities
{
    public abstract class EntityBase
    {
        [DataMember]
        [NotMapped]
        public int Id { get; set; }
    }
}
