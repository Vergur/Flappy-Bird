using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Button _jumpButton;
    
    private void Start()
    {
        _jumpButton.onClick.AddListener(JumpButton);
    }

    private void JumpButton()
    {
        _playerController.Jump();
    }
}