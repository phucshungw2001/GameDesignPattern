using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomMonsterNormal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform monsterPosition;
    AbstractFactory factory;
    void Start()
    {
        factory = FindObjectOfType<AbstractFactory>();
        factory.positionMonster = monsterPosition;
        factory.GetComponent<AbstractFactory>().RandomMonster();
    }
}
