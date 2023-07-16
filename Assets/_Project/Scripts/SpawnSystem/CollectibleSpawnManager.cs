using UnityEngine;
using Utilities;

namespace Platformer {
    public class CollectibleSpawnManager : EntitySpawnManager {
        [SerializeField] CollectibleData[] collectibleData;
        [SerializeField] float spawnInterval = 1f;
        
        EntitySpawner<Collectible> spawner;
        
        CountdownTimer spawnTimer;
        int counter;

        protected override void Awake() {
            base.Awake();

            spawner = new EntitySpawner<Collectible>(
                new EntityFactory<Collectible>(collectibleData),
                spawnPointStrategy);
            
            spawnTimer = new CountdownTimer(spawnInterval);
            spawnTimer.OnTimerStop += () => {
                if (counter++ >= spawnPoints.Length) {
                    spawnTimer.Stop();
                    return;
                }
                Spawn();
                spawnTimer.Start();
            };
        }
        
        void Start() => spawnTimer.Start();
        
        void Update() => spawnTimer.Tick(Time.deltaTime);

        public override void Spawn() => spawner.Spawn();
    }
}