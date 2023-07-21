using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolObjectMap : MonoBehaviour
{
    public static BoolObjectMap instance;

    private List<GameObject> poolObjects = new List<GameObject>();

    [SerializeField]
    private GameObject[] mapList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < mapList.Length; i++)
        {
            GameObject obj1 = Instantiate(mapList[i]);
            GameObject obj2 = Instantiate(mapList[i]);
            GameObject obj3= Instantiate(mapList[i]);
            GameObject obj4 = Instantiate(mapList[i]);
            GameObject obj5 = Instantiate(mapList[i]);
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(false);
            poolObjects.Add(obj1);
            poolObjects.Add(obj2);
            poolObjects.Add(obj3);
            poolObjects.Add(obj4);
            poolObjects.Add(obj5);

        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            int randomMap = Random.Range(0, poolObjects.Count);
            
            if (!poolObjects[randomMap].activeInHierarchy)
            {
                return poolObjects[randomMap];
            }
        }
        return null;
    }
}
