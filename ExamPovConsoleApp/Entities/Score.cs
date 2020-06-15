using EventFlow.Entities;
using ExamPovConsoleApp.Ids;
using ExamPovConsoleApp.ValueObjects;

namespace ExamPovConsoleApp.Entities
{
    public class Score : Entity<ScoreId>
    {
        public ProctorId ProctorId { get; private set; }
        public QuestionId QuestionId { get; private set; }
        public Grade Grade { get; private set; }

        public Score(ScoreId id, ProctorId proctorId, Grade grade, QuestionId questionId) : base(id)
        {
            ProctorId = proctorId;
            Grade = grade;
            QuestionId = questionId;
        }
    }
}