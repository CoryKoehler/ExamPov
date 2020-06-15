using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using EventFlow.Sagas;
using EventFlow.Sagas.AggregateSagas;
using EventFlow.ValueObjects;
using ExamPovApi.Aggregates;
using ExamPovApi.Entities;
using ExamPovApi.Events;
using ExamPovApi.Ids;

namespace ExamPovApi.Sagas
{
    public class ExamScoringSagaId : SingleValueObject<string>, ISagaId
    {
        public ExamScoringSagaId(string value) : base(value) { }
    }

    public class ExamScoringSagaLocator : ISagaLocator
    {
        public Task<ISagaId> LocateSagaAsync(IDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var examId = domainEvent.GetIdentity() as ExamId;
            var examScoringSagaId = new ExamScoringSagaId($"examscoringsaga-{examId.GetGuid()}");
            return Task.FromResult<ISagaId>(examScoringSagaId);
        }
    }

    public class ExamScoringSaga : AggregateSaga<ExamScoringSaga, ExamScoringSagaId, ExamScoringSagaLocator>,
        ISagaIsStartedBy<ExamAggregate, ExamId, ScoringStarted>,
        ISagaHandles<ExamAggregate, ExamId, ScoreReceived>,
        IApply<ExamScoringSaga.ExamScoringSagaStarted>,
        IApply<ExamScoringSaga.ExamScoringSagaScoreReceived>,
        IApply<ExamScoringSaga.ExamScoringSagaCompleted>
    {
        public bool AllQuestionsScored { get; set; }
        public Dictionary<Question, Answer> QuestionsAndStudentAnswers { get; set; }
        public List<Score> Scores { get; set; }


        public ExamScoringSaga(ExamScoringSagaId id) : base(id)
        {
            QuestionsAndStudentAnswers = new Dictionary<Question, Answer>();
            Scores = new List<Score>();
        }

        public Task HandleAsync(IDomainEvent<ExamAggregate, ExamId, ScoringStarted> domainEvent, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            foreach (var answer in domainEvent.AggregateEvent.StudentAnswers)
            {
                //if something blows up somehow somewhere we got a duplicate answer per question
                var question = domainEvent.AggregateEvent.Questions.Single(_ => _.Id == answer.Id);
                QuestionsAndStudentAnswers.TryAdd(question, answer);
            }

            Emit(new ExamScoringSagaStarted());
            return Task.CompletedTask;
        }

        public Task HandleAsync(IDomainEvent<ExamAggregate, ExamId, ScoreReceived> domainEvent, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            Emit(new ExamScoringSagaScoreReceived(domainEvent.AggregateEvent.Score));
            CheckIfExamScoringIsCompleted(domainEvent.AggregateEvent);
            HandleExamScoringCompletion(domainEvent.AggregateIdentity);
            return Task.CompletedTask;
        }

        private void HandleExamScoringCompletion(ExamId examId)
        {
            if (AllQuestionsScored)
                Emit(new ExamScoringSagaCompleted(examId));
        }

        private void CheckIfExamScoringIsCompleted(ScoreReceived aggregateEvent)
        {
            AllQuestionsScored = QuestionsAndStudentAnswers
                .All(questionsAndStudentAnswer =>
                    questionsAndStudentAnswer.Key.Id == aggregateEvent.Score.QuestionId);
        }

        public void Apply(ExamScoringSagaStarted aggregateEvent)
        {
        }

        public void Apply(ExamScoringSagaScoreReceived aggregateEvent)
        {
            Scores.Add(aggregateEvent.Score);
        }

        public void Apply(ExamScoringSagaCompleted aggregateEvent)
        {
            Complete();
        }

        [EventVersion("ExamScoringSagaStarted", 1)]
        public class ExamScoringSagaStarted : AggregateEvent<ExamScoringSaga, ExamScoringSagaId>
        { }

        [EventVersion("ExamScoringSagaScoreReceived", 1)]
        public class ExamScoringSagaScoreReceived : AggregateEvent<ExamScoringSaga, ExamScoringSagaId>
        {
            public Score Score { get; private set; }
            public ExamScoringSagaScoreReceived(Score score)
            {
                Score = score;
            }
        }

        [EventVersion("ExamScoringSagaCompleted", 1)]
        public class ExamScoringSagaCompleted : AggregateEvent<ExamScoringSaga, ExamScoringSagaId>
        {
            public ExamId ExamId { get; private set; }

            public ExamScoringSagaCompleted(ExamId examId)
            {
                ExamId = examId;
            }
        }
    }
}
