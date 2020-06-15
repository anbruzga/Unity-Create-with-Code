using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    private float spawnRangeX = 23;
    private float spawnPosZ = 35;

    private float startDelay = 2;
    private float spawnMaxFrequency = 5f;
    private float spawnMixFrequency = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, RandomInterval());

        InvokeRepeating("SpawnLineOfAnimals", startDelay * 1, RandomInterval() * 5);

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    float RandomInterval()
    {
        float interval = Random.Range(spawnMixFrequency, spawnMaxFrequency);
        return interval;
    }

    void SpawnRandomAnimal()
    {
        //random animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // random location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);


        Instantiate(animalPrefabs[animalIndex], spawnPos,
            animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLineOfAnimals()
    {

        StartCoroutine(SomeCoroutine());
       
    }

    private IEnumerator SomeCoroutine()
    {

        //random animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);


        // random variation
        int variation = Random.Range(1, 1);
        int repeater = Random.Range(0, 2);
        float waitTime = (float)(Random.Range(10, 25) / 100.0);

        for (int j = 0; j < repeater; j++)
        {
            
            switch (variation)
            {
                case 0:
                    for (int i = (int)-spawnRangeX; i < spawnRangeX; i += 4)
                    {
                        yield return new WaitForSeconds(waitTime);
                        Vector3 spawnPos = new Vector3(i, 0, spawnPosZ);
                        Instantiate(animalPrefabs[animalIndex], spawnPos,
                            animalPrefabs[animalIndex].transform.rotation);

                    }
                    break;
                case 1:
                    for (int i = (int)spawnRangeX; i > -spawnRangeX; i -= 4)
                    {
                        yield return new WaitForSeconds(waitTime);
                        Vector3 spawnPos = new Vector3(i, 0, spawnPosZ);
                        Instantiate(animalPrefabs[animalIndex], spawnPos,
                            animalPrefabs[animalIndex].transform.rotation);

                    }
                    break;
                case 2:
                    for (int i = 0; i < spawnRangeX; i += 4)
                    {
                        yield return new WaitForSeconds(waitTime);
                        Vector3 spawnPos = new Vector3(i, 0, spawnPosZ);
                        Instantiate(animalPrefabs[animalIndex], spawnPos,
                            animalPrefabs[animalIndex].transform.rotation);

                        Vector3 spawnPos2 = new Vector3(-i, 0, spawnPosZ);
                        Instantiate(animalPrefabs[animalIndex], spawnPos2,
                            animalPrefabs[animalIndex].transform.rotation);

                    }
                
                    break;

            }
        }
    }
}
