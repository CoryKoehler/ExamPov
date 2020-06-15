using System;

namespace ExamPovApi.Controllers.Requests
{
    public class AssignExamRequest
    {
        public string ExamCode { get; set; }
        public Guid StudentId { get; set; }
    }
}
