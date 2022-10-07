using System.ComponentModel.DataAnnotations;

namespace PatientManager.Domain.Common.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void SetUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }
    }
}
