using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ShipWreck : MonoBehaviour
{
    [SerializeField] bool PlayerCanPay = false;
    [SerializeField] Transform boatPos;
    GameObject boat;
    Rigidbody2D rb;
    PlayerVar player;
    private void Awake() {
        player = FindObjectOfType<PlayerVar>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        transform.position = new Vector3(boatPos.position.x + 1f,transform.position.y,transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PlayerCanPay = true;
        }
        if(other.tag == "boat")
        {
            boat = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PlayerCanPay = false;
        }
    }
    public void pay(InputAction.CallbackContext context)
    {
        if(context.started && PlayerCanPay && player.score >= 10) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
            boat.GetComponent<boat>().payed = true;
            GetComponent<BoxCollider2D>().enabled = false;
            player.score -= 10;
        }
        else if(context.started && PlayerCanPay && player.score < 10) 
        {
            Debug.Log("duit dk cukup tolol");
        }
    }
}
