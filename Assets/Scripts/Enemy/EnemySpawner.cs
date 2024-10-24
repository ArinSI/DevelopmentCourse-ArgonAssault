using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnFrequency = 5.0f;

    private Transform SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWithDelay", 0.1f);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(EnemyPrefab, SpawnLocation);
            yield return new WaitForSeconds(SpawnFrequency);
        }
    }

    private void StartWithDelay()
    {
        SpawnLocation = GetComponent<Transform>();
        StartCoroutine(SpawnRoutine());
    }
}
