using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Subscribers;
using ExamPovApi.Aggregates;
using ExamPovApi.Ids;
using ExamPovApi.Sagas;
using ExamPovApi.ValueObjects;

namespace ExamPovApi.Subscribers
{
    public class FinalExamGradeSubscriber : ISubscribeAsynchronousTo<ExamScoringSaga, ExamScoringSagaId,
        ExamScoringSaga.ExamScoringSagaCompleted>
    {
        private readonly IAggregateStore _aggregateStore;

        public FinalExamGradeSubscriber(IAggregateStore aggregateStore)
        {
            _aggregateStore = aggregateStore;
        }

        public async Task HandleAsync(
            IDomainEvent<ExamScoringSaga, ExamScoringSagaId, ExamScoringSaga.ExamScoringSagaCompleted> domainEvent,
            CancellationToken cancellationToken)
        {
            var examAggregate =
                await _aggregateStore.LoadAsync<ExamAggregate, ExamId>(domainEvent.AggregateEvent.ExamId,
                    cancellationToken);

            //TODO implement some real logic based on the ExamCode/ExamType
            var gradePercent = examAggregate.Scores.Select(_ => _.Grade.GradePercent).Average();

            examAggregate.FinalGradeAssigned(
                new Grade(gradePercent, GetGradeValueBasedOnGradePercent(gradePercent)));
        }

        private static string GetGradeValueBasedOnGradePercent(double gradePercent)
        {
            //TODO switch expression could be enum/extensionmethod/etc
            string gradeValue = "E";
            return (gradeValue switch
            {
                "A" => gradePercent > 90.00,
                "B" => gradePercent > 80.00,
                "C" => gradePercent > 70.00,
                "D" => gradePercent > 60.00,
                "E" => gradePercent < 60.00,
                _ => throw new System.NotImplementedException(),
            }).ToString();
        }
    }
}