using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private bool openTrigger;
    [SerializeField] private bool closeTrigger;
    public GameObject door;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}
