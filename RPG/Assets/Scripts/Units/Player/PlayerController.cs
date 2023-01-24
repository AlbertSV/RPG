using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RPG.Units.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerControls _controls;
        private StatsAssistance _stats;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.GameMap.FastAttack.performed += OnFastAttack;
            _controls.GameMap.StrongAttack.performed += OnStrongAttack;
        }
        private void Update()
        {
            OnMovement();
        }

        private void OnMovement()
        {
            var direction = _controls.GameMap.Movement.ReadValue<Vector2>();
            var velocity = new Vector3(direction.x, 0f, direction.y);

            transform.position += velocity * _stats.GetSpeed() * Time.deltaTime;
        }

        private void OnFastAttack(CallbackContext context)
        {
            //todo
        }

        private void OnStrongAttack(CallbackContext context)
        {
            //todo
        }
           

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }
        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}