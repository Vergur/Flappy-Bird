using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    private float _jumpStrength = 2f;
    private float _gravity = -5f;
    private Vector3 _position;
    
    private const float MultiplyConst = 1f;
    
    private void Update()
    {
        _position.y += _gravity * Time.deltaTime * MultiplyConst;
        _player.transform.position += _position * Time.deltaTime * MultiplyConst;
    }

    public void Jump()
    {
        _position = Vector3.up * _jumpStrength;
    }
}
