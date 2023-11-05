using System.Collections.Generic;
using LocationGenerator.Grid;
using UnityEngine;

namespace LocationGenerator.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new DecorativeElements", menuName = "StaticData/DecorativeElements", order = 2)]
    public class DecorativeElements : ScriptableObject
    {
        [SerializeField] private GridObject[] _gridObjects;

        public IReadOnlyCollection<GridObject> GridObjects => _gridObjects;
    }
}