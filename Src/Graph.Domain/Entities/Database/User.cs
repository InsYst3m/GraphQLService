using System.ComponentModel.DataAnnotations;

namespace Graph.Domain.Entities.Database
{
    public class User
    {
        public User(UserSettings userSettings, string email)
        {
            ArgumentNullException.ThrowIfNull(userSettings, nameof(userSettings));

            Settings = userSettings;
            Email = string.IsNullOrWhiteSpace(email)
                ? throw new ArgumentNullException(email)
                : email;
        }

        public long Id { get; set; }

        public long? TelegramUserId { get; set; }
        public string? Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public long ChatId { get; set; }

        public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public IList<UsersFollowingCryptoAssets> FollowedCryptoAssets { get; set; } = new List<UsersFollowingCryptoAssets>();

        public UserSettings Settings { get; set; }
    }
}
