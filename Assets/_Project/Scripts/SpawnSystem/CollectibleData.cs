using UnityEngine;

namespace Platformer {
    [CreateAssetMenu(fileName = "CollectibleData", menuName = "Platformer/Collectible Data")]
    public class CollectibleData : EntityData {
        public int score;
        // additional properties specific to collectibles
    }
}