using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    
    public float yRangeMax;
    public float yRangeMin;

    //The time between particles spawning
    public float timeBetween;
    float timeBetweenTimer;

    //Length of the season, if the change button is not pressed;
    public float seasonLength;
    float seasonTimer;

    //The number that will be multiplied by harshness to determine how many particles will spawn
    public int particleNumber;

    //particle is made public so it can be assigned as a preset
    public GameObject particle;
    public List<GameObject> particleList;

    public int season; // 1 is Snow, 2 is Rain, 3 is Sandstorm

    void Start()
    {
        timeBetweenTimer = timeBetween;
        particleList = new List<GameObject>();
        seasonTimer = seasonLength;


    }

    // Update is called once per frame
    void Update()
    {

        // Once the season is over, all of the particles that belong to it are destroyed.
        seasonTimer -= Time.deltaTime;
        if (seasonTimer < 0) 
        {
            SeasonChange();

        }
    
        timeBetweenTimer -= Time.deltaTime;

        if (timeBetweenTimer < 0)
        {
            timeBetweenTimer = timeBetween;
            for (int i = 0; i < particleNumber; i++)
            {
                GameObject newParticle = Instantiate(particle);
                newParticle.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);
                particleList.Add(newParticle);

            }

        }



    }

    public void SeasonChange()
    {
        seasonTimer = seasonLength;
        for (int i = 0; i < particleList.Count; i++)
        {
            Destroy(particleList[i]);

        }

        particleList = new List<GameObject>();

        season++;

        if (season > 3)
        {
            season = 1;
        }
    }
}
