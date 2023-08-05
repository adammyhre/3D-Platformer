using UnityEngine;
using UnityEngine.Events;

namespace Platformer {
    public abstract class EventListener<T> : MonoBehaviour {
        [SerializeField] EventChannel<T> eventChannel;
        [SerializeField] UnityEvent<T> unityEvent;

        protected void Awake() {
            eventChannel.Register(this);
        }
        
        protected void OnDestroy() {
            eventChannel.Deregister(this);
        }
        
        public void Raise(T value) {
            unityEvent?.Invoke(value);
        }
        
    }
    public class EventListener : EventListener<Empty> { }
}