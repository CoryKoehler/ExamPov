using System;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Commands
{
    public class ReceiveScoreCommand : Command<ExamAggregate, ExamId, ReceiveScoreExecutionResult>
    {
        public ProctorId ProctorId { get; }
        public double GradePercent { get; }
        public QuestionId QuestionId { get; }
       
        public ReceiveScoreCommand(Guid examId, Guid proctorId, double gradePercent,
            QuestionId questionId) : base(ExamId.With(examId))
        {
           ProctorId = ProctorId.With(proctorId);
           GradePercent = gradePercent;
           QuestionId = questionId;
        }
    }
}