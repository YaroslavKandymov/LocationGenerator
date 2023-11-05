using UnityEngine;

namespace LocationGenerator.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new PlayerData", menuName = "StaticData/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}