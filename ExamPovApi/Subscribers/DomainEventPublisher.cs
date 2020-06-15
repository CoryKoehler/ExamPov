using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Subscribers;

namespace ExamPovApi.Subscribers
{
    public class DomainEventPublisher : ISubscribeSynchronousToAll
    {
        public DomainEventPublisher()
        {
            
        }

        public async Task HandleAsync(IReadOnlyCollection<IDomainEvent> domainEvents,
            CancellationToken cancellationToken)
        {
            //send events that occur in eventflow to external systems here
        }
    }
}
