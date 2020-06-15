using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Events
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