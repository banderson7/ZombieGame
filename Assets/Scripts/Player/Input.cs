using UnityEngine;

namespace ZombieGame.Player
{
    public class Input : MonoBehaviour
    {
        private InputActions _inputActions;

        private void Awake()
        {
            _inputActions = new InputActions();
        }

        private void Start()
        {
            var look = GetComponent<Look>();
            var movement = GetComponent<Movement>();
            
            _inputActions.Player.Look.performed += ctx => look.SetLookInput(ctx.ReadValue<Vector2>());
            _inputActions.Player.Look.canceled += ctx => look.SetLookInput(ctx.ReadValue<Vector2>());

            _inputActions.Player.Move.performed += ctx => movement.SetMovement(ctx.ReadValue<Vector2>());
            _inputActions.Player.Move.canceled += ctx => movement.SetMovement(ctx.ReadValue<Vector2>());
            
            _inputActions.Enable();
        }
    }
}
