using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using ExamPovApi.Commands;
using ExamPovApi.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamPovApi.Controllers
{
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public ExamController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("exams")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AssignExam([FromBody] AssignExamRequest request, CancellationToken cancellationToken)
        {
            var command = new AssignExamCommand(request.ExamCode, request.StudentId);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.ExamId);

            return StatusCode(500);
        }

        [HttpPut]
        [Route("exams/submit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> StudentExamAnswersSubmittal([FromBody] StudentExamAnswersSubmittalRequest request, CancellationToken cancellationToken)
        {
            var command = new StudentExamAnswersSubmittalCommand(request.ExamId, request.StudentId, request.Answers);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }

        [HttpPut]
        [Route("exams/scoring")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ExamScoringStart([FromBody] ExamScoringStartRequest request, CancellationToken cancellationToken)
        {
            var command = new StartScoringCommand(request.ExamId);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }

        [HttpPut]
        [Route("exams/scoring")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ExamScoreReceived([FromBody] ExamReceiveScoreRequest request, CancellationToken cancellationToken)
        {
            var command = new ReceiveScoreCommand(request.ExamId, request.ProctorId,
                request.GradePercent, request.QuestionId, request.AnswerId);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }
    }
}
