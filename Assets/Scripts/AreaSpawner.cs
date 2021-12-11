using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] areaPrefabs;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private int spawnAreaAtstart = 2;
    [SerializeField]
    private float distanceToNext = 30;
    private int areaIndex = 0;
    private void Awake()
    {
        for (int i = 0;i< spawnAreaAtstart; i++){
            SpawnArea();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int playerIndex = (int)(player.position.y / distanceToNext);
        if(playerIndex == areaIndex - 1)
        {
            SpawnArea();
        }
    }
    private void SpawnArea()
    {
        int index = Random.Range(0, areaPrefabs.Length);
        GameObject clone = Instantiate(areaPrefabs[index]);
        clone.transform.position = Vector3.up * distanceToNext * areaIndex;
        areaIndex++;

    }
}
