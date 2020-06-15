using EventFlow.Core;

namespace ExamPovApi.Ids
{
    public class ExamId : Identity<ExamId>
    {
        public ExamId(string value) : base(value) { }
    }
}
