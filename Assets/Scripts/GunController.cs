using UnityEngine;
using System; 
public class GunController : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _force = 500f;
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SpawnBullet();
        }
    }
    private void SpawnBullet() {
        Rigidbody rigidbody = Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        rigidbody.AddForce(_spawnPoint.up * _force);
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}