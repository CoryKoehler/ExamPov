using EventFlow.Entities;
using ExamPovApi.Ids;
using ExamPovApi.ValueObjects;

namespace ExamPovApi.Entities
{
    public class Score : Entity<ScoreId>
    {
        public ProctorId ProctorId { get; private set; }
        public QuestionId QuestionId { get; private set; }
        public AnswerId AnswerId { get; private set; }
        public Grade Grade { get; private set; }

        public Score(ScoreId id, ProctorId proctorId, Grade grade, QuestionId questionId, AnswerId answerId) : base(id)
        {
            ProctorId = proctorId;
            Grade = grade;
            QuestionId = questionId;
            AnswerId = answerId;
        }
    }
}