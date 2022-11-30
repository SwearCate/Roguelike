using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform Player;
    public float smoothing;
    public Vector3 offset;

    void Update()
    {
        if (Player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, Player.transform.position + offset, smoothing);
            transform.position = Player.position + offset;
        }
    }

}
