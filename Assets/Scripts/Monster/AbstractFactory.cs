using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
    public Transform positionMonster;
    public abstract void RandomMonster();
    public abstract void RandomMonsterFly();
}
