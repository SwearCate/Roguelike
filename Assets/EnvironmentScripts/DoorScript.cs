using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject[] enemies;

    private bool enemiesCleared;
    private bool switchesCleared;
    public GameObject[] doors;

    // Start is called before the first frame update
    void Start()
    {
        if (enemies.Length == 0)
            enemiesCleared = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int enemiesAliveCount = 0;

        for (var i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemiesAliveCount++;
            }
        }

        if (enemiesAliveCount == 0)
        {
            OpenDoor(gameObject);
        }

    }

    public void OpenDoor(GameObject doors)
    {
        doors.SetActive(false);
    }

    public void CloseDoor(GameObject doors)
    {
        doors.SetActive(true);
    }

}
