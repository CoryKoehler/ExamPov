using System;
using System.Collections.Generic;
using System.Linq;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Controllers.Requests;
using ExamPovApi.Entities;
using ExamPovApi.Ids;

namespace ExamPovApi.Commands
{
    public class StudentExamAnswersSubmittalCommand : Command<ExamAggregate, ExamId, StudentExamAnswersSubmittalExecutionResult>
    {
        public StudentId StudentId { get; set; }
        public List<Answer> Answers { get; set; }

        public StudentExamAnswersSubmittalCommand(Guid examId, Guid studentId, List<AnswersDto> answers) : base(ExamId.With(examId))
        {
            StudentId = StudentId.With(studentId);
            Answers = answers.Select(_ => new Answer(QuestionId.With(_.QuestionId),
                StudentId.With(studentId), _.AnswerText)).ToList();
        }
    }
}
