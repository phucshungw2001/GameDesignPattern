using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomMonsterNormal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform monsterPosition;
    AbstractFactory factory;
    RandomTrap trap;

    void Start()
    {
        trap = FindObjectOfType<RandomTrap>();
        int random = Random.Range(0, 100);
        if (trap.random == 1)
        {
            if (random <= 70)
            {
                factory = FindObjectOfType<AbstractFactory>();
                factory.positionMonster = monsterPosition;
                factory.GetComponent<AbstractFactory>().RandomMonster();
            }
        }
        
    }
}
