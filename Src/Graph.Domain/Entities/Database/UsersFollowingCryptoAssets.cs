namespace Graph.Domain.Entities.Database
{
    public class UsersFollowingCryptoAssets
    {
        public UsersFollowingCryptoAssets(User user, CryptoAsset cryptoAsset)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentNullException.ThrowIfNull(cryptoAsset, nameof(cryptoAsset));

            User = user;
            CryptoAsset = cryptoAsset;
        }

        public long UserId { get; set; }
        public User User { get; set; }

        public long CryptoAssetId { get; set; }
        public CryptoAsset CryptoAsset { get; set; }

        // TODO: followers tracking params
    }
}
