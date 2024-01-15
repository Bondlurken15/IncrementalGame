using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OboyGlassSpawner : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject oboyGlas;
    [SerializeField] bool spawnImages = false;
    [SerializeField] float spawnDelay = 1.0f; 

    void Start()
    {
        StartCoroutine(SpawnImagesWithDelay());
    }

    IEnumerator SpawnImagesWithDelay()
    {
        while (spawnImages)
        {
            SpawnOboyGlas();

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnOboyGlas()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-960, 960), 581);
        GameObject newOboyGlas = Instantiate(oboyGlas, spawnPosition, Quaternion.identity);
        newOboyGlas.transform.SetParent(canvas.transform, false);
    }
}
