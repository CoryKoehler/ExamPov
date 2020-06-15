using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovApi.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Ids;

namespace ExamPovApi.Events
{
    [EventVersion("StudentExamAnswersSubmitted", 1)]
    public class StudentExamAnswersSubmitted : AggregateEvent<ExamAggregate, ExamId>
    {
        public StudentId StudentId { get; }
        public List<Answer> Answers { get; }


        public StudentExamAnswersSubmitted(StudentId studentId, List<Answer> answers)
        {
            StudentId = studentId;
            Answers = answers;
        }
    }
}