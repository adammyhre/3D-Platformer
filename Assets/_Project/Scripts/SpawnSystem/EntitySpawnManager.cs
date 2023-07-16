using UnityEngine;

namespace Platformer {
    public abstract class EntitySpawnManager : MonoBehaviour {
        [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Linear;
        [SerializeField] protected Transform[] spawnPoints;
        
        protected ISpawnPointStrategy spawnPointStrategy;

        protected enum SpawnPointStrategyType {
            Linear,
            Random
        }

        protected virtual void Awake() {
            spawnPointStrategy = spawnPointStrategyType switch {
                SpawnPointStrategyType.Linear => new LinearSpawnPointStragegy(spawnPoints),
                SpawnPointStrategyType.Random => new RandomSpawnPointStrategy(spawnPoints),
                _ => spawnPointStrategy
            };
        }

        public abstract void Spawn();
    }
}