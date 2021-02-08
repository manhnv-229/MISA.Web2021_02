using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kimerce.Backend.Domain.BaseEntities
{
    /// <summary>
    /// Thực thể có mã kiểu uint
    /// </summary>
    public class BaseEntityInt : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
