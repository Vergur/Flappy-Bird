using System;
using System.Collections.Generic;
using UnityEngine;

public class TubesController : MonoBehaviour
{
    [SerializeField] private GameObject _tubesPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TubeDestroyer _destroyPoint;
    private List<GameObject> _inactiveStash;
    private List<GameObject> _activeStash;

    private void Start()
    {
        _destroyPoint.OnTubeDestroy += DestroyTube;
        CreateStash();
        InvokeRepeating(nameof(SpawnTube), 1, 1);
    }

    private void CreateStash()
    {
        _activeStash = new List<GameObject>();
        _inactiveStash = new List<GameObject>();

        for (int i = 0; i < 10; i++)
        {
            var tube = Instantiate(_tubesPrefab, _spawnPoint);
            tube.SetActive(false);
            _inactiveStash.Add(tube);
        }
    }

    private void SpawnTube()
    {
        if (_inactiveStash.Count <= 0) return;
        
        _activeStash.Add(_inactiveStash[0]);
        _inactiveStash[0].SetActive(true);
        _inactiveStash.RemoveAt(0);
    }

    private void DestroyTube(GameObject tube)
    {
        tube.SetActive(false);
        _inactiveStash.Add(tube);
        _activeStash.Remove(tube);
        tube.transform.position = _spawnPoint.position;
    }
    
    private void Update()
    {
        foreach (var tube in _activeStash)
        {
            tube.transform.position += Time.deltaTime * Vector3.left;
        }
    }

    private void OnDestroy()
    {
        _destroyPoint.OnTubeDestroy -= DestroyTube;
    }
}
