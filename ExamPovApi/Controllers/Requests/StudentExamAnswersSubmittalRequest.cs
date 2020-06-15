using System;
using System.Collections.Generic;

namespace ExamPovApi.Controllers.Requests
{
    public class StudentExamAnswersSubmittalRequest
    {
       public Guid ExamId { get; set; }
       public Guid StudentId { get; set; }
       public List<AnswersDto> Answers { get; set; }
    }

    public class AnswersDto
    {
        public Guid QuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}
