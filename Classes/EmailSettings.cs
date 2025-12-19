namespace palmHillsapp.Classes
{
    public class EmailSettings
    {
        public required string server { get; set; } = default!;
        public required int port { get; set; }
        public required string Email { get; set; } = default!;
        public required string Password { get; set; } = default!;
        public required string SenderName { get; set; } = default!;

    }
}
