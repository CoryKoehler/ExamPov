using System.Text.Json.Serialization;
using EventFlow.Core;
using EventFlow.ValueObjects;

namespace ExamPovConsoleApp.Ids
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ScoreId : Identity<ScoreId>
    {
        public ScoreId(string value) : base(value) { }
    }
}
