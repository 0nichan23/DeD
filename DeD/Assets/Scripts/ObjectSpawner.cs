using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> TreesToSpawn = new List<GameObject>();
    public float TreesPerChunk;
    public Bounds chunkbounds;
    public GameObject Trees;
    public float SpawnerPerChunk;
    public List<GameObject> SpawnersToCreate = new List<GameObject>();
    public GameObject Spawners;

    public static ObjectSpawner Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Activate()
    {
        StartCoroutine("Startspawning");
    }
    Vector3 randomPoint()
    {
        //Debug.Log(chunkbounds.min + " " + chunkbounds.max);
        Vector3 pos = new Vector3(Random.Range(-1190, 1190), 25, Random.Range(-1190, 1190));
        return pos;
    }

    void spawnTree(Vector3 origin)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, -Vector3.up, out hit))
        {
            //Debug.Log("raycast hit something at " + hit.point);
            if (hit.transform.tag == "World")
            {
                if (hit.point.y > 5.8)
                {
                    GameObject go = Instantiate(TreesToSpawn[Random.Range(0, TreesToSpawn.Count - 1)], hit.point, new Quaternion());
                    go.transform.SetParent(Trees.transform);
                    Debug.Log("spawned a tree at " + hit.point);
                }
            }
        }
    }
    void spawnMob(Vector3 origin)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, -Vector3.up, out hit))
        {
            //Debug.Log("raycast hit something at " + hit.point);
            if (hit.transform.tag == "World")
            {
                if (hit.point.y > 2)
                {
                    GameObject go = Instantiate(SpawnersToCreate[Random.Range(0, SpawnersToCreate.Count - 1)], hit.point, new Quaternion());
                    go.transform.SetParent(Spawners.transform);
                    Debug.Log("created a mob spawner at " + hit.point);
                }
            }
        }
    }

    IEnumerator Startspawning()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < TreesPerChunk; i++)
        {
            spawnTree(randomPoint());
        }
        for (int i = 0; i < SpawnerPerChunk; i++)
        {
            spawnMob(randomPoint());
        }
    }
}
