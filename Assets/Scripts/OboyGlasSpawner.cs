using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OboyGlasSpawner : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject oboyGlas;
    [SerializeField] bool spawnOboyGlas = false;
    [SerializeField] float spawnDelay = 1.0f;

    bool isCoroutineRunning = false;

    void Update()
    {
        if (spawnOboyGlas && !isCoroutineRunning)
        {
            StartCoroutine(SpawnImagesWithDelay());
        } 
    }

    IEnumerator SpawnImagesWithDelay()
    {
        isCoroutineRunning = true;
        
        while (spawnOboyGlas)
        {
            SpawnOboyGlas();

            yield return new WaitForSeconds(spawnDelay);
        }

        isCoroutineRunning = false;
    }

    public void ActivateFrenzyEffect()
    {
        spawnOboyGlas = !spawnOboyGlas;
    }

    void SpawnOboyGlas()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-960, 960), 581);
        GameObject newOboyGlas = Instantiate(oboyGlas, spawnPosition, Quaternion.identity);
        newOboyGlas.transform.SetParent(canvas.transform, false);
    }
}
