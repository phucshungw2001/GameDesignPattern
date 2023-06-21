using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerController player;

    public Sprite[] spriteHealth;
    
    public UnityEngine.UI.Text imageHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent < PlayerController>();
    }

    // Update is called once per frame
     void FixedUpdate()
    {
       // imageHealth.sprite = spriteHealth[player.health];
    }
}
