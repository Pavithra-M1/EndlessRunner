using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SpawnCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        PlatformSpawner.instance.SpawnPlatform();
        Destroy(gameObject,2f);
    }

    public void SpawnObstacle()
    {
        int x = Random.Range(0, 2);
        int rand = Random.Range(2, 5);
        Transform spawnpoint = transform.GetChild(rand).transform;
        Instantiate(obstacle[x], spawnpoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int rand = Random.Range(5, 8);
        Transform spawnpoint = transform.GetChild(rand).transform;
        Instantiate(coin, spawnpoint.position, coin.transform.rotation, transform);

        int rand1 = Random.Range(8, 11);
        Transform spawnpoint1 = transform.GetChild(rand1).transform;
        Instantiate(coin, spawnpoint1.position, coin.transform.rotation, transform);
    }
}
