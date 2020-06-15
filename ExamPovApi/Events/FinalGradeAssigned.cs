using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovApi.Aggregates;
using ExamPovApi.Ids;
using ExamPovApi.ValueObjects;

namespace ExamPovApi.Events
{
    [EventVersion("FinalGradeAssigned", 1)]
    public class FinalGradeAssigned : AggregateEvent<ExamAggregate, ExamId>
    {
        public Grade Grade { get; private set; }
        public FinalGradeAssigned(Grade grade)
        {
            Grade = grade;
        }
    }
}