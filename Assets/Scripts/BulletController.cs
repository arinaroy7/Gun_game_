using UnityEngine;
using System;
public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab; 
    public void AddForce() {
        bulletPrefab.AddForce(10,500,0);
    }
}