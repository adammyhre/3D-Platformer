using UnityEngine;

namespace Platformer {
    public interface ISpawnPointStrategy {
        Transform NextSpawnPoint();
    }
}