using System.Collections.Generic;
using EventFlow.Aggregates.ExecutionResults;
using ExamPovConsoleApp.Entities;

namespace ExamPovConsoleApp.CommandHandlers.Results
{
    public class StudentExamAnswersSubmittalExecutionResult : ExecutionResult
    {
        public StudentExamAnswersSubmittalExecutionResult(string examId, 
            List<Answer> aggregateStudentAnswers,
            bool isSuccess)
        {
            ExamId = examId;
            AggregateStudentAnswers = aggregateStudentAnswers;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string ExamId { get; }
        public List<Answer> AggregateStudentAnswers { get; }
    }
}