using System;
using System.Collections.Generic;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Commands
{
    public class StudentExamAnswersSubmittalCommand : Command<ExamAggregate, ExamId, StudentExamAnswersSubmittalExecutionResult>
    {
        public StudentId StudentId { get; set; }
        public List<Answer> Answers { get; set; }

        public StudentExamAnswersSubmittalCommand(Guid examId, Guid studentId, List<Answer> answers) : base(ExamId.With(examId))
        {
            StudentId = StudentId.With(studentId);
            Answers = answers;
        }
    }
}
