using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    PlayerVar player;
    void Start()
    {
        player = FindObjectOfType<PlayerVar>();
    }
    void Update()
    {
        text.text = "x" + player.ammo.ToString();
    }
}
