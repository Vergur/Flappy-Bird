using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnPlayerDied;
    public Action OnPlayerScore;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Barricade":
            {
                OnPlayerDied?.Invoke();
                break;
            }
            case "Scoring":
            {
                OnPlayerScore?.Invoke();
                break;
            }
        }
    }
}
