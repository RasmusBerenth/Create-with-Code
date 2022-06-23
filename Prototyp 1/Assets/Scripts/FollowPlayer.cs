using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -8);

    // Update is called once per frame
    void LateUpdate()
    {
        //Offset the camera by adding to the players position
        transform.position = player.transform.position + offset;
    }
}
