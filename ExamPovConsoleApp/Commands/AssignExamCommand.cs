using System;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Commands
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
