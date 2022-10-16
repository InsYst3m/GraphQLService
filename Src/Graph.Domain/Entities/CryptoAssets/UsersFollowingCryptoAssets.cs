using Graph.Domain.Entities.Common;

namespace Graph.Domain.Entities.CryptoAssets
{
    public class UsersFollowingCryptoAssets
    {
        public long UserId { get; set; }
        public User User { get; set; } = null!;

        public long CryptoAssetId { get; set; }
        public CryptoAsset CryptoAsset { get; set; } = null!;

        // TODO: followers tracking params
    }
}
