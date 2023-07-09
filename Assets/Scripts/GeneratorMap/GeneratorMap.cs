using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMap : MonoBehaviour
{
    [SerializeField]
    private Transform level_square;
    [SerializeField]
    private List<Transform> level_square_list;
    [SerializeField]
    private PlayerController player_controller;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = level_square.Find("EndPosition").position;
        
        for(int i=0; i < 5; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player_controller.GetPosition(), lastEndPosition) < 20)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform choseLevelPart = level_square_list[Random.Range(0,level_square_list.Count)];
        Transform lastLevelTransform = SpawnLevelPart(choseLevelPart,lastEndPosition);
        lastEndPosition = lastLevelTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart (Transform levelPart,Vector3 spawnPosition)
    {
        Transform levePartTranform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levePartTranform;
    }
 

}
