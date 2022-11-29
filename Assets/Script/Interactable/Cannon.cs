using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject cannonBall;
    [SerializeField] GameObject effect;
    [SerializeField] Transform  cannonHole;
    public void shoot()
    {
        GetComponent<Animator>().SetTrigger("shoot");
    }
    public void fire()
    {
        Instantiate(cannonBall,cannonHole.position,Quaternion.identity);
        effect.SetActive(true);
    }
    public void stop()
    {
        effect.SetActive(false);
    }
}
