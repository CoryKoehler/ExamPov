using System;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Ids;

namespace ExamPovApi.Commands
{
    public class ReceiveScoreCommand : Command<ExamAggregate, ExamId, ReceiveScoreExecutionResult>
    {
        public ProctorId ProctorId { get; }
        public double GradePercent { get; }
        public QuestionId QuestionId { get; }
        public AnswerId AnswerId { get; }

        public ReceiveScoreCommand(Guid examId, Guid proctorId, double gradePercent,
            QuestionId questionId, AnswerId answerId) : base(ExamId.With(examId))
        {
           ProctorId = ProctorId.With(proctorId);
           GradePercent = gradePercent;
           QuestionId = questionId;
           AnswerId = answerId;
        }
    }
}