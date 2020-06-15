using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Commands;
using ExamPovApi.Entities;
using ExamPovApi.Ids;
using ExamPovApi.ValueObjects;

namespace ExamPovApi.CommandHandlers
{
    public class ReceiveScoreCommandHandler : CommandHandler<ExamAggregate, ExamId, ReceiveScoreExecutionResult, ReceiveScoreCommand>
    {
        public ReceiveScoreCommandHandler() { }

        public override async Task<ReceiveScoreExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            ReceiveScoreCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var scoreId = ScoreId.New;
            aggregate.ScoreReceived(new Score(scoreId, command.ProctorId, new Grade(command.GradePercent), command.QuestionId, command.AnswerId));

            return new ReceiveScoreExecutionResult(scoreId.GetGuid().ToString(), true);
        }
    }
}