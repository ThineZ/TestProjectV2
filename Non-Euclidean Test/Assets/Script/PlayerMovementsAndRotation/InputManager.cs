using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMovement
{
    public class InputManager : MonoBehaviour
    {
        // Input Action Script
        [Header("Input Action")]
        private PlayerMovement Actions;
        private PlayerMovement.PlayerActions OnMove;
        private PlayerLook Look;

        private void Awake()
        {
            Actions = new PlayerMovement();
            OnMove = Actions.Player;

            // Assigning script to the component
            Look = GetComponent<PlayerLook>();
        }

        private void LateUpdate()
        {
            Look.ProcessLook(OnMove.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            OnMove.Enable();
        }

        private void OnDisable()
        {
            OnMove.Disable();
        }
    }
}
