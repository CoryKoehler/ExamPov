using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Events
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