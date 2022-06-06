using System.ComponentModel.DataAnnotations;

namespace Graph.Domain.Entities.Database
{
    public class User
    {
        public long Id { get; set; }

        public long? TelegramUserId { get; set; }
        public string? Username { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public long ChatId { get; set; }

        public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public UserSettings Settings { get; set; } = null!;
    }
}
