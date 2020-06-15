using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Commands;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.CommandHandlers
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
