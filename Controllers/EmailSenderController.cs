using Microsoft.AspNetCore.Mvc;
using palmHillsapp.DTOs;
using palmHillsapp.Interfaces;
using palmHillsapp.Classes;
using palmHillsapp.Services;

namespace palmHillsapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailSenderController> _logger;

        public EmailSenderController(IEmailService emailService, ILogger<EmailSenderController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> BookCall([FromBody] EmailSenderDTOs request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _emailService.SendBookCallEmailAsync(new EmailSender
                {
                    FullName = request.FullName,
                    EmailAddress = request.EmailAddress,
                    phoneNumber = request.phoneNumber,
                    Message = request.Message,
                    InterestedIn = request.InterestedIn
                });

                _logger.LogInformation("Email request processed successfully for {Email}", request.EmailAddress);

                return Ok(new
                {
                    success = true,
                    message = "Request sent successfully",
                    data = new
                    {
                        fullName = request.FullName,
                        email = request.EmailAddress,
                        phone = request.phoneNumber,
                        interestedIn = request.InterestedIn.ToString()
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email for {Email}", request.EmailAddress);
                return StatusCode(500, new
                {
                    success = false,
                    message = "Failed to send email. Please try again later.",
                    error = ex.Message
                });
            }
        }
    }
}
