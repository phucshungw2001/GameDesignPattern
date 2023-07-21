using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] Map;
    public bool checkSpawnMap;
    public Transform positionMap;
    private void Start()
    {
    }
    private void Update()
    {
        if(!checkSpawnMap)
        {
            SpawnLeverMap();
            checkSpawnMap= true;
        }
    }
    private void SpawnLeverMap()
    {
        GameObject map = (GameObject)BoolObjectMap.instance.GetPoolObject();
        int mapRandom= Random.Range(0,Map.Length);
        float mapY=0;
        if (Random.Range(0,10)>=4)
        {
            mapY = Random.Range(0,0.5f);

        }if(Random.Range(0, 10) < 4)
        {
            mapY = Random.Range(-1.2f, 0.5f);

        }
        if (positionMap.transform.position.y + mapY >= -1.8 && positionMap.transform.position.y + mapY <= 1.8)
        {
            //Transform leverPartTranform= Instantiate(Map[mapRandom],new Vector3((float)6,positionMap.transform.position.y+mapY),Quaternion.identity);
            map.transform.position = new Vector3((float)6, positionMap.transform.position.y + mapY);
            map.SetActive(true);
        }
        else
        {
            //Transform leverPartTranform = Instantiate(Map[mapRandom], new Vector3((float)6,-1.8f), Quaternion.identity);
            map.transform.position = new Vector3((float)6, -1.8f);
            map.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            checkSpawnMap = true;
            positionMap = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Land"))
        {
            checkSpawnMap = false;
        }
    }
}
