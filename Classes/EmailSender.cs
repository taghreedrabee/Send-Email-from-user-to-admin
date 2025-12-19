using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace palmHillsapp.Classes
{
    public class EmailSender
    {
        public int id { get; set; }
        public string FullName { get; set; } = default!;
        public int phoneNumber { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public project InterestedIn { get; set; }
        public string Message { get; set; }
    }

    public enum project
    {
        jirian,
        badya,
        palmHills,
        All
    };
}
