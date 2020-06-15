using System.Text.Json.Serialization;
using EventFlow.Core;
using EventFlow.ValueObjects;

namespace ExamPovConsoleApp.Ids
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ProctorId : Identity<ProctorId>
    {
        public ProctorId(string value) : base(value) { }
    }
}
