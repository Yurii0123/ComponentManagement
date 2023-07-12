using TCM.Core.Entities.Interfaces;

namespace TCM.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {

        public int Id { get; set; }

        /* [NotMapped]
         public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

         public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
         public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
         public void ClearDomainEvents() => _domainEvents.Clear();*/
    }
}
