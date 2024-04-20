using System;
using System.Collections.Generic;
using UnityEngine;

public class TubesController : MonoBehaviour
{
    [SerializeField] private GameObject _tubesPrefab;
    [SerializeField] private Transform _spawnPoint;
    private List<GameObject> _stash;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _stash.Add(Instantiate(_tubesPrefab, _spawnPoint));
        }
    }
}
