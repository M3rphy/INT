using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    //czas po kt�rym sie pojawiaj� przeciwnicy 
    public float spawnRate = 1f;
    //odniesienie do prefaba przeciwnik�w
    [SerializeField] private GameObject enemyPrefabs;
    //parametry potrzebne do obracania do oko�a planszy
    public float rotateSpeed;
    private float timer;
    private float positionX;
    private float positionY;

    //rozpoczenie odliczania do powstania kolejnego przeciwnika
    void Start()
    {
        StartCoroutine(Spawner());
    }

    //funkcja kt�ra sie wykonuje po ka�dym zdobyciu nowego poziomu zmniejszaj�ca czas po kt�rym powstaj� nowi przeciwnicy 
    public void increaseSpawnSpeed()
    {
        if (GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().spawnRate - .2f > 0)
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().spawnRate -= .2f;
        }
    }
    //odliczanie do powstania nowego przeciwnika
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return wait;
            Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
        }
        
    }
    //obracanie sie obiektu do oko�a sceny
    private void Update()
    {
        timer += Time.deltaTime * rotateSpeed;
        positionX = -Mathf.Cos(timer) * 22;
        positionY = Mathf.Sin(timer) * 22;
        Vector2 pos = new Vector2(positionX, positionY);
        transform.position = pos + Vector2.zero;
    }
}
