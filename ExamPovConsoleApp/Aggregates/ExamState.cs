using System.Collections.Generic;
using EventFlow.Aggregates;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Events;
using ExamPovConsoleApp.Ids;
using ExamPovConsoleApp.ValueObjects;

namespace ExamPovConsoleApp.Aggregates
{
    public class ExamState : AggregateState<ExamAggregate, ExamId, ExamState>,
        IApply<ExamAssigned>, IApply<StudentExamAnswersSubmitted>, IApply<ScoringStarted>,
        IApply<ScoreReceived>, IApply<FinalGradeAssigned>
    {
        public string ExamCode { get; private set; }
        public StudentId StudentId { get; private set; }
      
        public List<Question> Questions { get; private set; }
        public List<Answer> StudentAnswers { get; private set; }
        public List<Score> Scores { get; private set; }
        public Grade FinalGrade { get; private set; }

        public ExamState()
        {
            Questions = new List<Question>();
            StudentAnswers = new List<Answer>();
            Scores = new List<Score>();
        }

        public void Apply(ExamAssigned aggregateEvent)
        {
            ExamCode = aggregateEvent.ExamCode;
            StudentId = aggregateEvent.StudentId;
            Questions = aggregateEvent.Questions;
        }

        public void Apply(ScoringStarted aggregateEvent)
        {
        }

        public void Apply(StudentExamAnswersSubmitted aggregateEvent)
        {
            StudentAnswers = aggregateEvent.Answers;
        }

        public void Apply(ScoreReceived aggregateEvent)
        {
            Scores.Add(aggregateEvent.Score);
        }

        public void Apply(FinalGradeAssigned aggregateEvent)
        {
            FinalGrade = aggregateEvent.Grade;
        }
    }
}
