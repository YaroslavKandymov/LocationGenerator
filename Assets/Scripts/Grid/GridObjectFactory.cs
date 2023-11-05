using System.Collections.Generic;
using System.Linq;
using LocationGenerator.Extensions;
using LocationGenerator.ScriptableObjects;
using UnityEngine;

namespace LocationGenerator.Grid
{
    public class GridObjectFactory
    {
        private readonly HashSet<Vector3Int> _collisionsMatrix;
        private readonly Transform _parent;
        private readonly ChunkData _chunkData;

        public GridObjectFactory(Transform parent, ChunkData chunkData)
        {
            _collisionsMatrix = new HashSet<Vector3Int>();

            _parent = parent;
            _chunkData = chunkData;
        }

        public void TryCreateGridObjects(GridObject[] gridObjects)
        {
            for (float x = -_chunkData.Size / 2f + _chunkData.Offset;
                 x < _chunkData.Size / 2f + _chunkData.Offset;
                 x++)
            {
                for (float z = -_chunkData.Size / 2f + _chunkData.Offset;
                     z < _chunkData.Size / 2f + _chunkData.Offset;
                     z++)
                {
                    TryCreateOnLayer(gridObjects, GridLayerType.OnGround, new Vector3Int((int) x, 0, (int) z));
                }
            }
        }

        private void TryCreateOnLayer(GridObject[] templates, GridLayerType layerType, Vector3Int gridPosition)
        {
            gridPosition.y = (int) layerType;

            if (_collisionsMatrix.Contains(gridPosition))
                return;

            var template = GetRandomTemplate(templates, layerType);

            if (template == null)
                return;

            var position = Vector3Extensions.GridToWorldPosition(gridPosition, _chunkData.CellSize);

            _collisionsMatrix.Add(gridPosition);

            var prefab = Object.Instantiate(template, _parent);
            prefab.transform.localPosition = new Vector3(position.x, position.y - _chunkData.Offset, position.z);
        }

        private GridObject GetRandomTemplate(GridObject[] templates, GridLayerType layerType)
        {
            var variants = templates.Where(template => template.LayerType == layerType);

            if (variants.Count() == 1)
                return variants.First();

            foreach (var template in variants)
            {
                if (template.Chance > Random.Range(0, 100))
                {
                    return template;
                }
            }

            return null;
        }
    }
}