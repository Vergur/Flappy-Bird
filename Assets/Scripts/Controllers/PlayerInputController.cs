using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();

        _playerInput.PlayerControl.Jump.started += ctx => _playerController.Jump();
    }

    private void OnDestroy()
    {
        _playerInput.Dispose();
        _playerInput.PlayerControl.Jump.started -= ctx => _playerController.Jump();
    }
}