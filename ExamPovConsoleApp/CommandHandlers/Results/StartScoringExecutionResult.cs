using EventFlow.Aggregates.ExecutionResults;

namespace ExamPovConsoleApp.CommandHandlers.Results
{
    public class StartScoringExecutionResult : ExecutionResult
    {
        public StartScoringExecutionResult(string examId, bool isSuccess)
        {
            ExamId = examId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string ExamId { get; }
    }
}
