using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player Player;
    private float _jumpStrength = 1.8f;
    private float _gravity = -6f;
    private Vector3 _position;
    private Coroutine _coroutine;
    
    private const float MultiplyConst = 1f;

    private void Start()
    {
        _coroutine = StartCoroutine(RotatePlayer(new Vector3(0, 0, -90), 0.5f));
    }

    private void Update()
    {
        _position.y += _gravity * Time.deltaTime * MultiplyConst;
        Player.transform.position += _position * Time.deltaTime * MultiplyConst;
    }

    public void Jump()
    {
        _position = Vector3.up * _jumpStrength;
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(RotatePlayer(new Vector3(0, 0, 45), 0.4f));
    }
    
    private IEnumerator RotatePlayer(Vector3 angle, float time)
    {
        Quaternion startRotation = Player.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angle);

        float startTime = Time.time;
        float endTime = startTime + time;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / time;
            Player.transform.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            yield return null;
        }

        Player.transform.rotation = endRotation; 
        
        _coroutine = StartCoroutine(RotatePlayer(new Vector3(0, 0, -90), 0.5f));
    }
}
