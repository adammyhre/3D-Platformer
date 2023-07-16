using UnityEngine;

namespace Platformer {
    public class EntityFactory<T> : IEntityFactory<T> where T : Entity {
        EntityData[] data;
        
        public EntityFactory(EntityData[] data) {
            this.data = data;
        }
        
        public T Create(Transform spawnPoint) {
            EntityData entityData = data[Random.Range(0, data.Length)];
            GameObject instance = GameObject.Instantiate(entityData.prefab, spawnPoint.position, spawnPoint.rotation);
            return instance.GetComponent<T>();
        }
    }
}