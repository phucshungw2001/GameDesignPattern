using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public float speed;
    SpeedMap speedMap;
    private void Start()
    {
        speedMap=FindObjectOfType<SpeedMap>();  
        speed = 0.9f;

    }
    private void Update()
    {
        speed = speedMap.speed;
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        movement = movement.normalized;
        transform.position += movement * speed * Time.deltaTime;
    }
}
