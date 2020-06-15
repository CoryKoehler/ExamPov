using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Commands;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;
using ExamPovConsoleApp.ValueObjects;

namespace ExamPovConsoleApp.CommandHandlers
{
    public class ReceiveScoreCommandHandler : CommandHandler<ExamAggregate, ExamId, ReceiveScoreExecutionResult, ReceiveScoreCommand>
    {
        public ReceiveScoreCommandHandler() { }

        public override async Task<ReceiveScoreExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            ReceiveScoreCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var scoreId = ScoreId.New;
            aggregate.ScoreReceived(new Score(scoreId, command.ProctorId, new Grade(command.GradePercent), command.QuestionId));

            return new ReceiveScoreExecutionResult(scoreId.GetGuid().ToString(), true);
        }
    }
}