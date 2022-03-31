using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstablePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private bool waiting = false;
    bool spawning = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.GameOver += Stop;
    }

    // Update is called once per frame
    void Update()
    {

        if (!waiting && spawning)
        {
            waiting = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        Instantiate(obstablePrefab, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(.5f, 2f));
        waiting = false;
    }

    private void Stop()
    {
        spawning = false;
    }
}
