using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer {
    public class RandomSpawnPointStrategy : ISpawnPointStrategy {
        List<Transform> unusedSpawnPoints;
        Transform[] spawnPoints;
        
        public RandomSpawnPointStrategy(Transform[] spawnPoints) {
            this.spawnPoints = spawnPoints;
            unusedSpawnPoints = new List<Transform>(spawnPoints);
        }
        
        public Transform NextSpawnPoint() {
            if (!unusedSpawnPoints.Any()) {
                unusedSpawnPoints = new List<Transform>(spawnPoints);
            }
            
            var randomIndex = Random.Range(0, unusedSpawnPoints.Count);
            Transform result = unusedSpawnPoints[randomIndex];
            unusedSpawnPoints.RemoveAt(randomIndex);
            return result;
        }
    }
}