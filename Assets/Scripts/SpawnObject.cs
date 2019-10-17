using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public Vector3 size;
    public GameObject CoinPrefab;
    public float spawnDelay = 15.0f;
    private GameObject coin;
    private bool isSpawning = false;

    // Use this for initialization
    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            SpawnCoin();

        if (coin == null && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(DelayedSpawnCoin(spawnDelay));
        }
    }

    private IEnumerator DelayedSpawnCoin(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2),
            0,
            Random.Range(-size.z / 2, size.z / 2));



        coin = Instantiate(CoinPrefab, pos, transform.rotation);
        isSpawning = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.localRotation, transform.localScale);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //Gizmos.DrawCube(transform.position, size);
        Gizmos.DrawCube(new Vector3(0, 0, 0), size);
    }
}
