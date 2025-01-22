using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn= true;
    [SerializeField] private int numOfEnemysType = 1;
    public float rotateSpeed;
    private float timer;
    private float positionX;
    private float positionY;

    void Start()
    {
      
        StartCoroutine(Spawner());
    }

    public void increaseSpawnSpeed()
    {
        if (GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().spawnRate - .2f > 0)
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().spawnRate -= .2f;
        }
    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, numOfEnemysType);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            

        }
        
    }
    private void Update()
    {
        timer += Time.deltaTime * rotateSpeed;
        positionX = -Mathf.Cos(timer) * 22;
        positionY = Mathf.Sin(timer) * 22;
        Vector2 pos = new Vector2(positionX, positionY);
        transform.position = pos + Vector2.zero;
    }
}
