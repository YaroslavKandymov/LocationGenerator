
using UnityEngine;

namespace LocationGenerator.Grid
{
    public class GridObject : MonoBehaviour
    {
        [SerializeField] private GridLayerType _layerType;
        [SerializeField] private int _chance;
        
        public GridLayerType LayerType => _layerType;
        public int Chance => _chance;

        private void OnValidate()
        {
            _chance = Mathf.Clamp(_chance, 1, 100);
        }
    }
}