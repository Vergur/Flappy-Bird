using System;
using UnityEngine;

public class TubeDestroyer : MonoBehaviour
{
    public Action<GameObject> OnTubeDestroy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tube")) OnTubeDestroy?.Invoke(other.gameObject);
    }
}