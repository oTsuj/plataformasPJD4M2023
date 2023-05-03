using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "SO/New Enemy", order = 0)]
    public class EnemySO : ScriptableObject
    {
        public int maxEnergy;
        public Sprite enemySprite;
    }
}