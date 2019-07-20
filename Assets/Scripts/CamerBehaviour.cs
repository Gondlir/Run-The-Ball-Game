using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamerBehaviour : MonoBehaviour
{  
    public GameObject player;
    private Vector3 distance;
    private float offset = -8f;

    void Start()
    {
        distance = player.transform.position;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(1.59f, 34.19f, player.transform.position.z + offset);
    }

}
