using System.Collections.Generic;
using UnityEngine;

public class SpawningAndListing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemy;
    public List<GameObject> enemyList;
    public Canvas endScreen;
    void Start()
    {
        enemyList = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            GameObject newEnemy = Instantiate(enemy); 
            newEnemy.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
            enemyList.Add(newEnemy);
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
            {
                enemyList.RemoveAt(i);
            }

            if (enemyList.Count == 0)
            {
                endScreen.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }
}
