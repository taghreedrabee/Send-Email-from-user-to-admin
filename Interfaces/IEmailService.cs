using palmHillsapp.DTOs;
using palmHillsapp.Classes;

namespace palmHillsapp.Interfaces

{
    public interface IEmailService
    {
        Task SendBookCallEmailAsync(EmailSender model);
    }
}
