using UnityEngine;

namespace LocationGenerator.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new ChunkData", menuName = "StaticData/ChunkData", order = 3)]
    public class ChunkData : ScriptableObject
    {
        [SerializeField] private GameObject _ground;
        [SerializeField] private GameObject _wall;
        [SerializeField] private ObstaclesData _obstaclesData;
        [SerializeField] private DecorativeElements _decorativeElements;
        [SerializeField] private int _size;
        [SerializeField] private float _cellSize;
        [SerializeField] private float _offset;

        public GameObject Ground => _ground;
        public GameObject Wall => _wall;
        public ObstaclesData ObstaclesData => _obstaclesData;
        public DecorativeElements DecorativeElements => _decorativeElements;
        public int Size => _size;
        public float CellSize => _cellSize;
        public float Offset => _offset;
    }
}