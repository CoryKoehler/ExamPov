using System.Collections.Generic;
using EventFlow.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Events;
using ExamPovApi.Ids;
using ExamPovApi.ValueObjects;

namespace ExamPovApi.Aggregates
{
    public class ExamAggregate : AggregateRoot<ExamAggregate, ExamId>
    {
        private readonly ExamState _state = new ExamState();

        public ExamAggregate(ExamId id) : base(id)
        {
            Register(_state);
        }

        public string ExamCode => _state.ExamCode;
        public StudentId StudentId => _state.StudentId;
        public List<Question> Questions => _state.Questions;
        public List<Answer> StudentAnswers => _state.StudentAnswers;
        public List<Score> Scores => _state.Scores;
        public Grade FinalGrade => _state.FinalGrade;

        public virtual void ExamAssigned(StudentId studentId, string examCode, List<Question> questionBank)
        {
            Emit(new ExamAssigned(studentId, examCode, questionBank));
        }

        public virtual void StudentExamAnswersSubmitted(StudentId studentId, List<Answer> answers)
        {
            Emit(new StudentExamAnswersSubmitted(studentId, answers), new Metadata());
        }

        public virtual void ScoringStarted()
        {
            Emit(new ScoringStarted(Questions, StudentAnswers), new Metadata());
        }

        public virtual void ScoreReceived(Score score)
        {
            Emit(new ScoreReceived(score), new Metadata());
        }

        public virtual void FinalGradeAssigned(Grade grade)
        {
            Emit(new FinalGradeAssigned(grade), new Metadata());
        }
    }
}
