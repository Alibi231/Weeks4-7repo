using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DuckerScript : MonoBehaviour
{
    public float duckSpeed = 0.5f;
    public CarSpawner spawn;
    public Canvas winScreen;
    public CarSpawner logSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            newPos.y += duckSpeed;
        } else if (Keyboard.current.sKey.wasPressedThisFrame) 
        {
            newPos.y -= duckSpeed;
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            newPos.x -= duckSpeed;
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            newPos.x += duckSpeed;
        }

        transform.parent = null; 

        for (int i = 0;  i < spawn.enemyList.Count; i++)
        {
            SpriteRenderer enemySR = spawn.enemyList[i].GetComponent<SpriteRenderer>();
            if (enemySR.bounds.Contains(newPos))
            {
                newPos = new Vector3(0, -4.5f, 0);
            }
        }

        for (int i = 0; i < logSpawn.enemyList.Count; i++)
        {
            SpriteRenderer enemySR = logSpawn.enemyList[i].GetComponent<SpriteRenderer>();
            if (enemySR.bounds.Contains(newPos))
            {
                transform.parent = logSpawn.enemyList[i].transform;
            }
        }

        if(newPos.y > -4 && newPos.y < -1 && transform.parent ==  null )
        {
            newPos = new Vector3(0, -4.5f, 0);
        }
        transform.position = newPos;

        if(newPos.y >= 4)
        {
            winScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
