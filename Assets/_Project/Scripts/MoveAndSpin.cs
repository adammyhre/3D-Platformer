using UnityEngine;
using DG.Tweening;

public class MoveAndSpin : MonoBehaviour {
    public float moveDistance = 1f; // The distance to move up and down
    public float moveTime = 1f; // The time to complete one up and down cycle
    public Ease moveEase = Ease.InOutQuad; // The easing function to use for the up and down motion
    public float spinSpeed = 1f; // The speed to spin at (degrees per second)
    public Vector3 spinAxis = Vector3.up; // The axis to spin around

    private Vector3 originalPosition;

    void Start() {
        originalPosition = transform.position;

        // Create a sequence to move the object up and then down
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(originalPosition.y + moveDistance, moveTime / 2).SetEase(moveEase));
        sequence.Append(transform.DOMoveY(originalPosition.y, moveTime / 2).SetEase(moveEase));
        sequence.SetLoops(-1); // loop indefinitely

        // Rotate the object continuously
        transform.DORotate(spinAxis * 360, spinSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }
}