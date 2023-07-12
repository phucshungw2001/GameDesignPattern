using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMap : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeIncrementSpeed = 15f;
    public float time;
    public float speed;
    void Start()
    {
        time = timeIncrementSpeed;
        speed = 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        incrementSpeed();
    }
    public void incrementSpeed()
    {
        if ((time -= Time.deltaTime) <= 0)
        {
            speed += 0.2f;
            time = timeIncrementSpeed;
        }
    }
}
