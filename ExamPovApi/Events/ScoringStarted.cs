using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovApi.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Ids;

namespace ExamPovApi.Events
{
    [EventVersion("ScoringStarted", 1)]
    public class ScoringStarted : AggregateEvent<ExamAggregate, ExamId>
    {
        public List<Question> Questions { get; }
        public List<Answer> StudentAnswers { get; }
        public ScoringStarted(List<Question> questions, List<Answer> studentAnswers)
        {
            Questions = questions;
            StudentAnswers = studentAnswers;
        }
    }
}