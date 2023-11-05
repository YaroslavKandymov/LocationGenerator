using System.Collections.Generic;
using LocationGenerator.Extensions;
using UnityEngine;

namespace LocationGenerator.Grid
{
    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] private Chunk _chunk;
        [SerializeField] private Transform _player;
        [SerializeField] private float _viewRadius;

        private readonly Dictionary<Vector3Int, Chunk> _collisionsMatrix = new();

        private float _cellSize;

        private void Update()
        {
            FillRadius(_player.position, _viewRadius);
        }

        private void FillRadius(Vector3 center, float viewRadius)
        {
            var cellCountOnAxis = (int) (viewRadius / _chunk.Size);
            _cellSize = _chunk.Size;

            var fillAreaCenter = Vector3Extensions.WorldToGridPosition(center, _cellSize);

            for (int x = -cellCountOnAxis; x < cellCountOnAxis + 1; x++)
            {
                for (int z = -cellCountOnAxis; z < cellCountOnAxis + 1; z++)
                {
                    var point = fillAreaCenter + new Vector3Int(x, 0, z);

                    TryCreateOnLayer(GridLayerType.Ground, point);
                  
                }
            }

            foreach (var point in _collisionsMatrix.Keys)
            {
                CheckDistance(Vector3Extensions.GridToWorldPosition(point, _cellSize), center);
            }
        }

        private void CheckDistance(Vector3 point, Vector3 center)
        {
            if (_viewRadius.SqrDistance(center, point) == false)
            {
                _collisionsMatrix[Vector3Extensions.WorldToGridPosition(point, _cellSize)].gameObject.SetActive(false);
            }
            else
            {
                _collisionsMatrix[Vector3Extensions.WorldToGridPosition(point, _cellSize)].gameObject.SetActive(true);
            }
        }

        private void TryCreateOnLayer(GridLayerType layerType, Vector3Int gridPosition)
        {
            gridPosition.y = (int) layerType;

            if (_collisionsMatrix.ContainsKey(gridPosition))
                return;

            var position = Vector3Extensions.GridToWorldPosition(gridPosition, _cellSize);

            var chunk = Instantiate(_chunk, position, Quaternion.identity, transform);

            _collisionsMatrix.Add(gridPosition, chunk);
        }
    }
}