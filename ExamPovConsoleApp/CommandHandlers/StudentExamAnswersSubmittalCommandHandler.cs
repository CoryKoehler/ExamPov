using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Commands;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.CommandHandlers
{
    public class StudentExamAnswersSubmittalCommandHandler : CommandHandler<ExamAggregate, ExamId, StudentExamAnswersSubmittalExecutionResult, StudentExamAnswersSubmittalCommand>
    {
        public StudentExamAnswersSubmittalCommandHandler() { }

        public override async Task<StudentExamAnswersSubmittalExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            StudentExamAnswersSubmittalCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            aggregate.StudentExamAnswersSubmitted(command.StudentId, command.Answers);

            return new StudentExamAnswersSubmittalExecutionResult(aggregate.Id.GetGuid().ToString(), aggregate.StudentAnswers, true);
        }
    }
}
