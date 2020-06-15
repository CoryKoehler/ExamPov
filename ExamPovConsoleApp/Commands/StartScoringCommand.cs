using System;
using EventFlow.Commands;
using ExamPovConsoleApp.Aggregates;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp.Commands
{
    public class StartScoringCommand : Command<ExamAggregate, ExamId, StartScoringExecutionResult>
    {
        public StartScoringCommand(Guid id) : base(ExamId.With(id))
        {
        }
    }
}
