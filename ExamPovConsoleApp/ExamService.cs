using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Commands;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;

namespace ExamPovConsoleApp
{
    public interface IExamService
    {
        Task<AssignExamExecutionResult> AssignExamAsync(string examCode, Guid studentId, CancellationToken cancellationToken);
        Task<StudentExamAnswersSubmittalExecutionResult> StudentAnswersSubmittalAsync(Guid examId, Guid studentId,
            List<Answer> answers, CancellationToken cancellationToken);
        Task<string> StartScoring(Guid examId, CancellationToken cancellationToken);
        Task<string> ReceiveScore(Guid examId, Guid proctorId, double gradePercent,
            QuestionId questionId, CancellationToken cancellationToken);
    }

    public class ExamService : IExamService
    {
        private readonly ICommandBus _commandBus;

        public ExamService(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public async Task<AssignExamExecutionResult> AssignExamAsync(string examCode, Guid studentId, CancellationToken cancellationToken)
        {
            var command = new AssignExamCommand(examCode, studentId);
            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result;
        }

        public async Task<StudentExamAnswersSubmittalExecutionResult> StudentAnswersSubmittalAsync(Guid examId, Guid studentId,
            List<Answer> answers, CancellationToken cancellationToken)
        {
            var command = new StudentExamAnswersSubmittalCommand(examId, studentId, answers);
            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result;
        }

        public async Task<string> StartScoring(Guid examId, CancellationToken cancellationToken)
        {
            var command = new StartScoringCommand(examId);
            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result.ExamId;
        }
        public async Task<string> ReceiveScore(Guid examId, Guid proctorId,
            double gradePercent, QuestionId questionId, CancellationToken cancellationToken)
        {
            var command = new ReceiveScoreCommand(examId, proctorId, gradePercent, questionId);
            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result.ScoreId;
        }
    }
}
