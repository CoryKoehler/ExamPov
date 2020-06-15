using System;
using ExamPovApi.Ids;

namespace ExamPovApi.Controllers.Requests
{
    public class ExamReceiveScoreRequest
    {
        public double GradePercent { get; set; }
        public Guid ExamId { get; set; }
        public Guid ProctorId { get; set; }
        public QuestionId QuestionId { get; set; }
        public AnswerId AnswerId { get; set; }
    }
}