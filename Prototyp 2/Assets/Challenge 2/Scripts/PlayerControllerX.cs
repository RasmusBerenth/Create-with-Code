using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnDuration = 3.0f;
    private float spawnTime;

    private void Start()
    {
        spawnTime = spawnDuration;
    }
    // Update is called once per frame
    void Update()
    {
        bool canSpawnDog = spawnTime >= spawnDuration;
        spawnTime += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnTime = 0;
        }
    }
}
