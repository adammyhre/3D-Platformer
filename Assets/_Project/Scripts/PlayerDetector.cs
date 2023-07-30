using UnityEngine;
using Utilities;

namespace Platformer {
    public class PlayerDetector : MonoBehaviour {
        [SerializeField] float detectionAngle = 60f; // Cone in front of enemy
        [SerializeField] float detectionRadius = 10f; // Large circle around enemy
        [SerializeField] float innerDetectionRadius = 5f; // Small circle around enemy
        [SerializeField] float detectionCooldown = 1f; // Time between detections
        [SerializeField] float attackRange = 2f; // Distance from enemy to player to attack
        
        public Transform Player { get; private set; }
        CountdownTimer detectionTimer;
        
        IDetectionStrategy detectionStrategy;

        void Start() {
            detectionTimer = new CountdownTimer(detectionCooldown);
            Player = GameObject.FindGameObjectWithTag("Player").transform; // Make sure to TAG the player!
            detectionStrategy = new ConeDetectionStrategy(detectionAngle, detectionRadius, innerDetectionRadius);
        }
        
        void Update() => detectionTimer.Tick(Time.deltaTime);

        public bool CanDetectPlayer() {
            return detectionTimer.IsRunning || detectionStrategy.Execute(Player, transform, detectionTimer);
        }

        public bool CanAttackPlayer() {
            var directionToPlayer = Player.position - transform.position;
            return directionToPlayer.magnitude <= attackRange;
        }
        
        public void SetDetectionStrategy(IDetectionStrategy detectionStrategy) => this.detectionStrategy = detectionStrategy;
        
        void OnDrawGizmos() {
            Gizmos.color = Color.red;

            // Draw a spheres for the radii
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
            Gizmos.DrawWireSphere(transform.position, innerDetectionRadius);

            // Calculate our cone directions
            Vector3 forwardConeDirection = Quaternion.Euler(0, detectionAngle / 2, 0) * transform.forward * detectionRadius;
            Vector3 backwardConeDirection = Quaternion.Euler(0, -detectionAngle / 2, 0) * transform.forward * detectionRadius;

            // Draw lines to represent the cone
            Gizmos.DrawLine(transform.position, transform.position + forwardConeDirection);
            Gizmos.DrawLine(transform.position, transform.position + backwardConeDirection);
        }
    }
}