using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerInteract _playerInteract;
    [SerializeField] private Animator _playerAnimator;
    private bool _isCanMove;
    private RaycastHit _hitInfo = new RaycastHit();
    private Interactable _currentInteractable;
    private bool _isInteracted;
    
    private void Awake()
    {
        _playerInput.actions["Attack"].performed += MovePlayer;         
    }
    
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            _isCanMove = false;
        } 
        else
        {
            _isCanMove = true;
        }    
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _playerAnimator.SetBool("IsIdle", true);
                    if (_isInteracted)
                    {
                        _playerInteract.RecieveResources(_currentInteractable.Resources,_currentInteractable.Value);
                        _currentInteractable.TakeResources();
                        _isInteracted = false;
                    }
                }
            }
        }
    }
    
    private void MovePlayer(InputAction.CallbackContext context)
    {
        if (_isCanMove)
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray.origin, ray.direction, out _hitInfo))
            {                
                if (_hitInfo.collider.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    _currentInteractable = interactable;
                    _isInteracted = true;
                }
                _agent.SetDestination(_hitInfo.point);
                _agent.Move(default);
                _playerAnimator.SetBool("IsIdle", false);
            }
        }        
    }    
}