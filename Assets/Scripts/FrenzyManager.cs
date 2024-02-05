using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrenzyManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject oboyGlas;
    [SerializeField] GameObject oboy;
    [SerializeField] bool isFrenzyActivated = false;
    [SerializeField] float spawnDelay = 1.0f;

    Vector3 standardOboyScale;
    bool isCoroutineRunning = false;

    private void Start()
    {
        standardOboyScale = oboy.gameObject.transform.localScale;
       
    }

    void Update()
    {
        if (isFrenzyActivated && !isCoroutineRunning)
        {
            StartCoroutine(SpawnImagesWithDelay());
        }
        if (isFrenzyActivated)
        {
            OboyPulse();
           
        }
    }

    public void ActivateFrenzyEffect()
    {
        isFrenzyActivated = !isFrenzyActivated;
    }

    void OboyPulse()
    {
        
    }

   
    void SpawnOboyGlas()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-960, 960), 581);
        GameObject newOboyGlas = Instantiate(oboyGlas, spawnPosition, Quaternion.identity);
        newOboyGlas.transform.SetParent(canvas.transform, false);
    }

    IEnumerator SpawnImagesWithDelay()
    {
        isCoroutineRunning = true;
        
        while (isFrenzyActivated)
        {
            SpawnOboyGlas();

            yield return new WaitForSeconds(spawnDelay);
        }

        isCoroutineRunning = false;
    }
}
