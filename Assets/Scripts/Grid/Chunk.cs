using System.Linq;
using LocationGenerator.ScriptableObjects;
using UnityEngine;

namespace LocationGenerator.Grid
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private ChunkData _chunkData;

        public float Size => _chunkData.Size * _chunkData.CellSize;

        private void Start()
        {
            Create();
        }

        private void Create()
        {
            var block = Instantiate(_chunkData.Ground, transform);
            var newSize = new Vector3(_chunkData.Size * _chunkData.CellSize, 1, _chunkData.Size * _chunkData.CellSize);
            block.transform.localScale = newSize;

            FillElements();
        }

        private void FillElements()
        {
            var gridObjectFactory = new GridObjectFactory(transform, _chunkData);
            
            gridObjectFactory.TryCreateGridObjects(_chunkData.ObstaclesData.GridObjects.ToArray());
            gridObjectFactory.TryCreateGridObjects(_chunkData.DecorativeElements.GridObjects.ToArray());
        }
    }
}