using System.Text.Json.Serialization;
using EventFlow.Core;
using EventFlow.ValueObjects;

namespace ExamPovConsoleApp.Ids
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class AnswerId : Identity<AnswerId>
    {
        public AnswerId(string value) : base(value) { }
    }
}
