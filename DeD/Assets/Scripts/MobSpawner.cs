using System.Collections;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float TimeBetweenSpawns;
    public bool Stop;
    float Mobcounter;

    private void Start()
    {
        Mobcounter = 0;
        StartCoroutine("Spawn");
    }



    IEnumerator Spawn()
    {
        GameObject go;

        go = Instantiate(ObjectToSpawn, transform.position, transform.rotation);
        Mobcounter++;
        Debug.Log("spawned aligator");
        go.gameObject.transform.SetParent(transform);
        yield return new WaitForSeconds(TimeBetweenSpawns);
        if (Mobcounter < 1)
        {
            go = Instantiate(ObjectToSpawn, transform.position, transform.rotation);
            go.gameObject.transform.SetParent(transform);
            Mobcounter++;
        }

    }


}
