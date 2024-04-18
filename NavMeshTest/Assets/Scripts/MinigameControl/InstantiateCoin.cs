using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoin : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawning = 5f;
    [SerializeField] private Renderer plane;
    private Vector3 planeSize;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private RunGame gameScript;
    // Start is called before the first frame update
    void Start()
    {
        planeSize = plane.bounds.size;
        StartCoroutine(SpawnCoin());
    }

    public IEnumerator SpawnCoin()
    {
        while (gameScript.gamePlaying)
        {
            Vector3 myVector = new Vector3(Random.Range(0f, planeSize.x - 3f), 1f, Random.Range(0f, planeSize.z - 3f));
            GameObject coinSpawned = Instantiate(coinPrefab, myVector, coinPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }
    }
}
