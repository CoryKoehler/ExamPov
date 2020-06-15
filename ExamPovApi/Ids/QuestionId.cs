using System.Text.Json.Serialization;
using EventFlow.Core;
using EventFlow.ValueObjects;

namespace ExamPovApi.Ids
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class QuestionId : Identity<QuestionId>
    {
        public QuestionId(string value) : base(value) { }
    }
}
