using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Commands;
using ExamPovApi.Ids;

namespace ExamPovApi.CommandHandlers
{
    public class StartScoringCommandHandler : CommandHandler<ExamAggregate, ExamId, StartScoringExecutionResult, StartScoringCommand>
    {
        public StartScoringCommandHandler() { }

        public override async Task<StartScoringExecutionResult> ExecuteCommandAsync(ExamAggregate aggregate,
            StartScoringCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.ScoringStarted();

            return new StartScoringExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
