using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> TreesToSpawn = new List<GameObject>();
    public float TreesPerChunk;
    public Bounds chunkbounds;
    public static ObjectSpawner Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    void spawnObject(Vector3 origin)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, -Vector3.up, out hit))
        {
            //Debug.Log("raycast hit something at " + hit.point);
            if (hit.transform.tag == "World")
            {
                if (hit.point.y > 5.8)
                {
                    Instantiate(TreesToSpawn[Random.Range(0, TreesToSpawn.Count - 1)], hit.point, new Quaternion());
                    Debug.Log("spawned a tree at " + hit.point);
                }
            }
        }
    }

    IEnumerator Startspawning()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < TreesPerChunk; i++)
        {
            spawnObject(randomPoint());
        }
    }
}
