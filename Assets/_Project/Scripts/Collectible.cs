using UnityEngine;

namespace Platformer {
    public class Collectible : Entity {
        [SerializeField] int score = 10; // FIXME set using Factory
        [SerializeField] IntEventChannel scoreChannel;

        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                scoreChannel.Invoke(score);
                Destroy(gameObject);
            }
        }
    }
}