using System.ComponentModel.DataAnnotations;
using palmHillsapp.Classes;

namespace palmHillsapp.DTOs

{
    public class EmailSenderDTOs
    {
        public required string FullName { get; set; }
        public required int phoneNumber { get; set; }
        public required string EmailAddress { get; set; }
        public project InterestedIn {  get; set; }
        public string Message { get; set; }
    }
}
