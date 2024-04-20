using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();

        _playerInput.PlayerControl.Jump.started += ctx => _playerController.Jump();
    }
}