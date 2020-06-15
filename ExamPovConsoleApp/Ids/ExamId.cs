using EventFlow.Core;

namespace ExamPovConsoleApp.Ids
{
    public class ExamId : Identity<ExamId>
    {
        public ExamId(string value) : base(value) { }
    }
}
