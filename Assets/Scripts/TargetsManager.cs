using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetsManager : MonoBehaviour // логика спавна мишеней 
{
    [SerializeField] private GameObject _prefab; 
    [SerializeField] private int _minTargetOfSpawn;
    [SerializeField] private int _maxTargetOfSpawn;
    [SerializeField] private float _minDistance; 
    [SerializeField] private Transform _spawnAreaMin;
    [SerializeField] private Transform _spawnAreaMax;
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
            Random.Range(_spawnAreaMin.position.x, _spawnAreaMax.position.x),
            Random.Range(_spawnAreaMin.position.y, _spawnAreaMax.position.y),
            Random.Range(_spawnAreaMin.position.z, _spawnAreaMax.position.z)
        );
        return spawnPosition;
    }
    private bool IsPositionValid(Vector3 newPosition) {
        return _spawnTargets.TrueForAll(existingTarget => existingTarget != null && Vector3.Distance(newPosition, existingTarget.transform.position) >= _minDistance);
    }
}