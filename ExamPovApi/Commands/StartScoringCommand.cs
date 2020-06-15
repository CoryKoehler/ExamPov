using System;
using EventFlow.Commands;
using ExamPovApi.Aggregates;
using ExamPovApi.CommandHandlers.Results;
using ExamPovApi.Ids;

namespace ExamPovApi.Commands
{
    public class StartScoringCommand : Command<ExamAggregate, ExamId, StartScoringExecutionResult>
    {
        public StartScoringCommand(Guid id) : base(ExamId.With(id))
        {
        }
    }
}
