using System.Collections.Generic;
using LocationGenerator.Grid;
using UnityEngine;

namespace LocationGenerator.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Obstacles", menuName = "StaticData/Obstacles", order = 1)]
    public class ObstaclesData : ScriptableObject
    {
        [SerializeField] private GridObject[] _gridObjects;

        public IReadOnlyCollection<GridObject> GridObjects => _gridObjects;
    }
}