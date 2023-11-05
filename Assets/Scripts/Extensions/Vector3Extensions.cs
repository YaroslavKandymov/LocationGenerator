using UnityEngine;

namespace LocationGenerator.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 GridToWorldPosition(Vector3Int gridPosition, float cellSize)
        {
            return new Vector3(
                gridPosition.x * cellSize,
                gridPosition.y * cellSize,
                gridPosition.z * cellSize);
        }

        public static Vector3Int WorldToGridPosition(Vector3 worldPosition, float cellSize)
        {
            return new Vector3Int(
                (int) (worldPosition.x / cellSize),
                (int) (worldPosition.y / cellSize),
                (int) (worldPosition.z / cellSize));
        }
        
        public static bool SqrDistance(this float distance, Vector3 self, Vector3 target)
        {
            var offset = target - self;
            float sqrLength = offset.sqrMagnitude;

            return sqrLength < distance * distance;
        }
    }
}