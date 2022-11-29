using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] GameObject bullet;
    [SerializeField] AnimatorOverrideController overrideControllers;
    [SerializeField] Transform gun;
    [SerializeField] float CD;
    int health = 3;
    float gap;

    private void Start() {
        gap = Time.time + CD;
        GetComponent<Animator>().runtimeAnimatorController = overrideControllers;
    }
    
    private void Update() 
    {
         if(gap <= Time.time)
         {
            GetComponent<Animator>().SetTrigger("shoot");
            gap = Time.time + CD;
         }
         if(health <= 0)
         {
            Destroy(gameObject);
         }
    }
    public void shoot()
    {
        Instantiate(bullet,gun.position,Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "cannonball")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "sword")
    {
        Destroy(other.gameObject);
        health--;
    }
    }
}
