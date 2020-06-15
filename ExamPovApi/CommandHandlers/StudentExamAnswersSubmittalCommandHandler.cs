using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Commands;
using ExamPovApi.Ids;

namespace ExamPovApi.CommandHandlers
{
    public class StudentExamAnswersSubmittalCommandHandler : CommandHandler<ExamAggregate, ExamId, StudentExamAnswersSubmittalExecutionResult, StudentExamAnswersSubmittalCommand>
    {
        public StudentExamAnswersSubmittalCommandHandler() { }

        public override async Task<StudentExamAnswersSubmittalExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            StudentExamAnswersSubmittalCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            aggregate.StudentExamAnswersSubmitted(command.StudentId, command.Answers);

            return new StudentExamAnswersSubmittalExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
