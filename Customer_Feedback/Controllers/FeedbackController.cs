using CustomerFeedbackSystem.Data;
using CustomerFeedbackSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerFeedbackSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }
    }
}
