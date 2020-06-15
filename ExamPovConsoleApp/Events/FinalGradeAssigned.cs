using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.Ids;
using ExamPovConsoleApp.ValueObjects;

namespace ExamPovConsoleApp.Events
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