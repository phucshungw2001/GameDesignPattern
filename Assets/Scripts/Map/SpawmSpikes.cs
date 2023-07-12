using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmSpikes : MonoBehaviour
{
    public GameObject spikes;
    public Transform point;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        int random= Random.Range(0, 100);
        if (random<=30)
        {
            spikes= Instantiate(spikes, point.transform.position, Quaternion.identity);
            spikes.transform.SetParent(parent);
        }
    }
}
