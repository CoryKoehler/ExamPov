using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Events
{
    [EventVersion("ScoreReceived", 1)]
    public class ScoreReceived : AggregateEvent<ExamAggregate, ExamId>
    {
        public Score Score { get; private set; }
        public ScoreReceived(Score score)
        {
            Score = score;
        }
    }
}