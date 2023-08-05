using System.Collections;
using TMPro;
using UnityEngine;

namespace Platformer {
    public class ScoreUI : MonoBehaviour {
        [SerializeField] TextMeshProUGUI scoreText;

        void Start() {
            UpdateScore();
        }

        public void UpdateScore() {
            StartCoroutine(UpdateScoreNextFrame());
        }
        
        IEnumerator UpdateScoreNextFrame() {
            // Make sure all logic has run before updating the score
            yield return null;
            scoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}