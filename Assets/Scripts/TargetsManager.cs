using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetsManager : MonoBehaviour // логика спавна мишеней 
{
    [SerializeField] public GameObject _prefab; 
    public int minTargetOfSpawn = 5;
    public int maxTargetOfSpawn = 5; 
    public Vector3 spawnAreaMin = new(-60f, 5f, -20f);
    public Vector3 spawnAreaMax = new(-40f, 15f, -10f);
    public float minDistance = 0.5f;
    private List<Vector3> targetPositions = new();
    private void Start() {
        int targetOfSpawn = Random.Range(minTargetOfSpawn, maxTargetOfSpawn+1);
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
        randomPosition = _getRandomPosition();
        if (_isPositionValid(randomPosition))
            {
                Instantiate(_prefab, randomPosition, Quaternion.Euler(90, 90, 90));
                targetPositions.Add(randomPosition); 
                return;
            }
        }
    }
    private Vector3 _getRandomPosition() {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        return new Vector3(randomX, 2, randomZ);
    }
    private bool _isPositionValid(Vector3 newPosition) {
        return targetPositions.TrueForAll(existingPosition => Vector3.Distance(newPosition, existingPosition) >= minDistance);
    }
}
