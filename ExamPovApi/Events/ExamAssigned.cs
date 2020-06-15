using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovApi.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Ids;

namespace ExamPovApi.Events
{
    [EventVersion("ExamAssigned", 1)]
    public class ExamAssigned : AggregateEvent<ExamAggregate, ExamId>
    {
        public StudentId StudentId { get; }
        public string ExamCode { get; }
        public List<Question> Questions { get; }
   

        public ExamAssigned(StudentId studentId, string examCode, List<Question> questions)
        {
            StudentId = studentId;
            ExamCode = examCode;
            Questions = questions;
        }
    }
}
