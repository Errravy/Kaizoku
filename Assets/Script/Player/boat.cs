using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform targetPos;
    [SerializeField] private float duration;
    Rigidbody2D rb;
    public bool payed = false;
    public float boatTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(payed)
        {
            boatGO();
        }
    }
    private void boatGO()
    {
            transform.position = Vector3.MoveTowards(transform.position,targetPos.position,speed *  Time.deltaTime);
    }
}
