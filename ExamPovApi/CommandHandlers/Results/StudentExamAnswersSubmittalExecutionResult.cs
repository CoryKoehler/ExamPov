﻿using EventFlow.Aggregates.ExecutionResults;

namespace ExamPovApi.CommandHandlers.Results
{
    public class StudentExamAnswersSubmittalExecutionResult : ExecutionResult
    {
        public StudentExamAnswersSubmittalExecutionResult(string examId, bool isSuccess)
        {
            ExamId = examId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string ExamId { get; }
    }
}