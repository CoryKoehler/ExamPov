using System;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Ids;

namespace ExamPovApi.Commands
{
    public class AssignExamCommand : Command<ExamAggregate, ExamId, AssignExamExecutionResult>
    {
        public string ExamCode { get; set; }
        public StudentId StudentId { get; set; }

        public AssignExamCommand(string examCode, Guid studentId) : base(ExamId.New)
        {
            ExamCode = examCode;
            StudentId = StudentId.With(studentId);
        }
    }
}
