using System.ComponentModel.DataAnnotations;

namespace BOC.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
