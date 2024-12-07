using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject knife;

    private float min_Y = -4f;
    private float max_Y = 4.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Corrected: Moved the method inside the class
    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        GameObject knifeClone = Instantiate(knife);

        float y = Random.Range(min_Y, max_Y);

        knifeClone.transform.position = new Vector2(transform.position.x, y);

        StartCoroutine(StartSpawning()); // Recursively start spawning again
    }
}
