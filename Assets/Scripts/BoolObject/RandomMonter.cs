using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            RandomMon();
    }

    private void RandomMon()
    {
        GameObject enemy = BoolObject.instance.GetPoolObject();
        if (enemy != null)
        {
            enemy.transform.position = GetRandomPosition();
            enemy.SetActive(true);
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Lấy vị trí ngẫu nhiên trong phạm vi màn hình
        float minX = -4f; // Ví dụ giá trị tối thiểu của x
        float maxX = 4f; // Ví dụ giá trị tối đa của x
        float minY = -1f; // Ví dụ giá trị tối thiểu của y
        float maxY = 3f; // Ví dụ giá trị tối đa của y

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, 0f);
    }
}
