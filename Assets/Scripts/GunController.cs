using UnityEngine;
using System; 
public class GunController : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _force = 500f;
    [SerializeField] private float _speedGun;

    Rigidbody rb;

    private float horizontal;
    private float vertical;
    private void Start() {
        	rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SpawnBullet();
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        MovementGun();
    }
    private void SpawnBullet() {
        Rigidbody rigidbody = Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        rigidbody.AddForce(_spawnPoint.up * _force);
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void MovementGun() {
        float forceMultipleer = _speedGun;
        rb.AddForce(horizontal*_speedGun, 0, vertical*_speedGun);

    }
}