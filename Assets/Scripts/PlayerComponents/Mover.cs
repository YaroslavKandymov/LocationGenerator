using UnityEngine;

namespace LocationGenerator.PlayerComponents
{
    public class Mover
    {
        private readonly SurfaceSlider _surfaceSlider;
        private readonly Rigidbody _rigidbody;

        public Mover(SurfaceSlider surfaceSlider, Rigidbody rigidbody)
        {
            _surfaceSlider = surfaceSlider;
            _rigidbody = rigidbody;
        }

        public void Move(Vector3 direction, float speed)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (speed * Time.deltaTime);

            var nextPosition = _rigidbody.position + offset;

            _rigidbody.MovePosition(nextPosition);
        }
    }
}