using System.Collections.Generic;
using EventFlow.Aggregates.ExecutionResults;

namespace ExamPovConsoleApp.CommandHandlers.Results
{
    public class AssignExamExecutionResult : ExecutionResult
    {
        public AssignExamExecutionResult(string examId, List<string> questionIds, bool isSuccess)
        {
            ExamId = examId;
            QuestionIds = questionIds;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string ExamId { get; }
        public List<string> QuestionIds { get; set; }
    }
}