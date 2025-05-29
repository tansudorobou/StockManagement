using System.Text.Json.Serialization;

namespace Domain.SeedWork {
    public abstract class BaseEntity {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected BaseEntity() {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(Guid id, DateTime createdAt, DateTime updatedAt) {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public void SetUpdated() {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
