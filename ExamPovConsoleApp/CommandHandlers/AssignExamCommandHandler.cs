using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Commands;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.CommandHandlers
{
    public class AssignExamCommandHandler : CommandHandler<ExamAggregate, ExamId, AssignExamExecutionResult, AssignExamCommand>
    {
        public AssignExamCommandHandler() { }

        public override async Task<AssignExamExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            AssignExamCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var questionBank = GenerateQuestionBank(command.ExamCode);
            aggregate.ExamAssigned(command.StudentId, command.ExamCode, questionBank);

            return new AssignExamExecutionResult(aggregate.Id.GetGuid().ToString(),
                questionBank.Select(_ => _.Id.GetGuid().ToString()).ToList(), true);
        }

        //TODO this should be a new bounded context or returned from external service
        private static List<Question> GenerateQuestionBank(string examCode)
        {
            return new List<Question>()
            {
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "True"),
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "True"),
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "True"),
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "True"),
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "False"),
                new Question(QuestionId.New, examCode,
                    "True or False: This is a question", "True"),
            };
        }
    }
}
