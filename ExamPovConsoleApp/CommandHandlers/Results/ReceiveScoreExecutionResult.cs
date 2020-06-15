using EventFlow.Aggregates.ExecutionResults;

namespace ExamPovConsoleApp.CommandHandlers.Results
{
    public class ReceiveScoreExecutionResult : ExecutionResult
    {
        public ReceiveScoreExecutionResult(string scoreId, bool isSuccess)
        {
            ScoreId = scoreId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string ScoreId { get; }
    }
}