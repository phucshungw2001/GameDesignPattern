using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : AbstractFactory
{
    public GameObject[] monster;
    public GameObject monsterfly;
    private GameObject monsterInstantiate;
    public override void RandomMonster()
    {
        int random = Random.Range(0,monster.Length);
        monsterInstantiate= Instantiate(monster[random], positionMonster.transform.position, Quaternion.identity);
        monsterInstantiate.transform.SetParent(positionMonster);
    }
    public override void RandomMonsterFly()
    {
        //monsterInstantiate = Instantiate(monsterfly, positionMonster.transform.position, Quaternion.identity);
        //monsterInstantiate.transform.SetParent(positionMonsterFly);
    }
}
