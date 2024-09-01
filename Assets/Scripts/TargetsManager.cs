using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetsManager : MonoBehaviour // логика спавна мишеней 
{
    [SerializeField] private GameObject _prefab; 
    [SerializeField] private int _minTargetOfSpawn;
    [SerializeField] private int _maxTargetOfSpawn;
    [SerializeField] private float _minDistance; 
    [SerializeField] private float _spawnAreaSize; 
    private List<TargetController> _spawnTargets = new();
    private void Start() {
        int targetOfSpawn = Random.Range(_minTargetOfSpawn, _maxTargetOfSpawn+1);
        SpawnTargets(targetOfSpawn);
    }
    public void SpawnTargets(int count) {
        for (int i=0; i<count; i++) {
            Spawn(); 
        }
    }
    public void Spawn() {
        Vector3 randomPosition;
        for (int attempts = 0; attempts < 30; attempts++) 
        {
        randomPosition = GetRandomPosition();
        if (IsPositionValid(randomPosition))
            {
                GameObject newTarget = Instantiate(_prefab, randomPosition, Quaternion.Euler(90,90,90));
                TargetController targetController = newTarget.GetComponent<TargetController>();
                _spawnTargets.Add(targetController); 
                return;
            }
        }
    }
    public Vector3 GetRandomPosition() {
        Vector3 spawnPosition = new(
            Random.Range(-_spawnAreaSize, _spawnAreaSize),
            2f, 
            Random.Range(-_spawnAreaSize, _spawnAreaSize)
        );
        return spawnPosition;
    }
    private bool IsPositionValid(Vector3 newPosition) {
        foreach (TargetController existingTarget in _spawnTargets) {
            if (existingTarget != null && Vector3.Distance(newPosition, existingTarget.transform.position) < _minDistance) {
                return false;
            }
        }
        return true;
    }
}