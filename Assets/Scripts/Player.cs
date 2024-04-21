using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnPlayerDied;
    public Action OnPlayerScore;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        switch (other.gameObject.tag)
        {
            case "Ground":
            case "Tube":
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
