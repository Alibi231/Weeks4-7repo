using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float yRangeMax;
    public float yRangeMin;
    public GameObject enemy;
    public List<GameObject> enemyList;
    void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject newEnemy = Instantiate(enemy); 
            newEnemy.transform.position = new Vector3(Random.Range(-15, -10), (float)Random.Range(yRangeMin, yRangeMax) / 2f, 0);
            enemyList.Add(newEnemy);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
