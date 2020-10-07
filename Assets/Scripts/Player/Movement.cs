using UnityEngine;

namespace ZombieGame.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        public int forwardSpeed;
        public int sideSpeed;
        
        private Vector2 _moveInput;
        private Rigidbody _rb2d;
        private readonly MovementCalculator _movementCalculator;

        public Movement()
        {
            _movementCalculator = new MovementCalculator();
        }
        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody>();

        }
        public void SetMovement(Vector2 input)
        {
            _moveInput = input;
        }

        private void FixedUpdate()
        {
            ApplyMovementInput();
        }

        private void ApplyMovementInput()
        {
            var isMoving = _movementCalculator.IsMoving(_rb2d.velocity);
            var hasMovementInput = _movementCalculator.HasMovementInput(_moveInput);
            
            if (!hasMovementInput && !isMoving) return;
            
            var newVelocity = _movementCalculator.CalculateNewVelocity(
                transform, _rb2d.velocity, _moveInput, forwardSpeed, sideSpeed);

            _rb2d.velocity = newVelocity;
        }
    }
}
