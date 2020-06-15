using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using ExamPovConsoleApp.CommandHandlers.Results;
using ExamPovConsoleApp.Entities;
using ExamPovConsoleApp.Ids;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using IContainer = Autofac.IContainer;

namespace ExamPovConsoleApp
{
    internal class Program
    {
        private static IConfiguration Configuration { get; set; }
        private static IContainer Container { get; set; }

        private static async Task Main(string[] args)
        {
            CancellationToken cancellationToken;
            RegisterServices();
            var examService = Container.Resolve<ExamService>();
            var proctorId = Guid.NewGuid();
            var studentId = Guid.NewGuid();

            var assignExamResult = await examService.AssignExamAsync("ABC", studentId, cancellationToken);
            Console.WriteLine($"Assign Exam Results: {assignExamResult}");

            var examId = Guid.Parse(assignExamResult.ExamId);
            var questionIds = assignExamResult.QuestionIds.Select(_ => Guid.Parse(_)).ToList();
            var studentAnswers = questionIds.Select(questionId => 
                new Answer(QuestionId.With(questionId), StudentId.With(studentId), "True")).ToList();

            var studentAnswerSubmittalResult = await examService.StudentAnswersSubmittalAsync(
                examId, studentId, studentAnswers, cancellationToken);
            Console.WriteLine($"Student Answers Submittal Results: {studentAnswerSubmittalResult}");

            var startScoringResult = await examService.StartScoring(examId, cancellationToken);
            Console.WriteLine($"Scoring started results: {startScoringResult}");

            var receiveScoreExecutionResults = new List<string>();
            foreach (var answer in studentAnswerSubmittalResult.AggregateStudentAnswers)
            {
                var receiveScoreResult = await examService.ReceiveScore(
                    examId, proctorId, 100.00, answer.Id, cancellationToken);
                receiveScoreExecutionResults.Add(receiveScoreResult);
            }
            Console.WriteLine($"Scoring results: {receiveScoreExecutionResults}");
        }

        private static void RegisterServices()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("local.settings.json")
                .AddEnvironmentVariables()
                .Build();


            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            ILogger logger = loggerFactory.CreateLogger<Program>();

            var mongoDbUri = Configuration.GetValue<string>("mongoDbUri");
            var mongoDbName = Configuration.GetValue<string>("mongoDbName");

            var containerBuilder = new ContainerBuilder().AddEventFlow(mongoDbUri, mongoDbName);

            containerBuilder.RegisterType<ExamService>().AsSelf().As<IExamService>();
            containerBuilder.RegisterInstance(logger);

            Container = containerBuilder.Build();
        }
    }
}
