using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BoolObject : MonoBehaviour
{
    public static BoolObject instance;
    public int poolSize;

    private List<GameObject> poolObjects = new List<GameObject>();

    [SerializeField]
    private GameObject monter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(monter);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
