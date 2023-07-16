using UnityEngine;

namespace Platformer {
    public class LinearSpawnPointStragegy : ISpawnPointStrategy {
        int index = 0;
        Transform[] spawnPoints;
        
        public LinearSpawnPointStragegy(Transform[] spawnPoints) {
            this.spawnPoints = spawnPoints;
        }
        
        public Transform NextSpawnPoint() {
            Transform result = spawnPoints[index];
            index = (index + 1) % spawnPoints.Length;
            return result;
        }
    }
}