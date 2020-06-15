using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovApi.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Ids;

namespace ExamPovApi.Events
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