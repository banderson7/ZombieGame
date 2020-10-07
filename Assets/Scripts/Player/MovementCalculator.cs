using UnityEngine;

namespace ZombieGame.Player
{
    public class MovementCalculator
    {
        public bool HasMovementInput(Vector2 input)
        {
            return input != Vector2.zero;
        }
        public bool IsMoving(Vector3 velocity)
        {
            return velocity != Vector3.zero;
        }
        public Vector3 CalculateNewVelocity(
            Transform transform, Vector3 velocity, Vector2 input, float forwardSpeed, float sideSpeed)
        {
            var currentFallSpeed = FallSpeed(velocity);

            var forwardVelocity = ForwardVelocity(transform, input, forwardSpeed);
            var sideVelocity = SideVelocity(transform, input, sideSpeed);

            var newVelocity = forwardVelocity + sideVelocity + currentFallSpeed;
            return newVelocity;
        }

        private Vector3 FallSpeed(Vector3 velocity)
        {
            var currentFallSpeed = new Vector3(0.0f, velocity.y, 0.0f);
            return currentFallSpeed;
        }

        private Vector3 SideVelocity(Transform transform, Vector2 input, float speed)
        {
            var sideVelocity = transform.right * (input.x * speed);
            return sideVelocity;
        }

        private Vector3 ForwardVelocity(Transform transform, Vector2 input, float speed)
        {
            var forwardVelocity = transform.forward * (input.y * speed);
            return forwardVelocity;
        }
    }
}