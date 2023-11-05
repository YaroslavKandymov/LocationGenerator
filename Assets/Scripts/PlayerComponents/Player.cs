using System;
using System.Collections;
using LocationGenerator.ScriptableObjects;
using UnityEngine;

namespace LocationGenerator.PlayerComponents
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Joystick _joystick;

        private Mover _mover;
        
        private void Start()
        {
            var surfaceSlider = new SurfaceSlider();
            _mover = new Mover(surfaceSlider, _rigidbody);

            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                float horizontal = _joystick.Horizontal;
                float vertical = _joystick.Vertical;

                if (Math.Abs(vertical) >= Mathf.Epsilon || Math.Abs(horizontal) >= Mathf.Epsilon)
                {
                    _mover.Move(new Vector3(horizontal, 0, vertical), _playerData.Speed);
                }
                
                yield return null;
            }
        }
    }
}