using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] Enemy;
    public float ScrollSpeed = 10f;
    public Transform SpawnPoint;
    private float Counter = 0f;

    void Start()
    {
        SpawnEmenies();
    }

    void SpawnEmenies()
    {
        if (ParallaxScroll.EndGame == false)
        {
            GameObject enemy = Instantiate(Enemy[Random.Range(0, Enemy.Length)], SpawnPoint.position, Quaternion.identity);
            enemy.transform.parent = transform;

            Counter = Random.Range(1.25f ,2);
        }
    }

    void Update()
    {
        if (ParallaxScroll.EndGame == false)
        {

            if (Counter <= 0.5)
            {
                SpawnEmenies();
            }
            else
            {
                Counter -= Time.deltaTime;
            }

            GameObject CurrentChild;
            for (int i = 0; i < transform.childCount; i++)
            {
                CurrentChild = transform.GetChild(i).gameObject;
                ScrollEnemy(CurrentChild);

                if(CurrentChild.transform.position.x <= -10)
                {
                    Destroy(CurrentChild);
                }
            }
        }
    }

    void ScrollEnemy(GameObject currentEnemies)
    {
        if (ParallaxScroll.EndGame == false)
        {
            currentEnemies.transform.position += Vector3.left * ScrollSpeed * Time.deltaTime;
        }
    }
}
