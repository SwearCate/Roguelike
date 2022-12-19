using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject coin;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (var i = 0; i < 20; i++)
            {
                Instantiate(coin, Player.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
}
