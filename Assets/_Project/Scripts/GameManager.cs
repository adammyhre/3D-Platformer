using UnityEngine;

namespace Platformer {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }
        
        public int Score { get; private set; }
        
        void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
            }
        }
        
        public void AddScore(int score) {
            Score += score;
        }
    }
}