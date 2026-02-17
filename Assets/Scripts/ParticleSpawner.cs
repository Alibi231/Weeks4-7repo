using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject raindrop;
    public List<GameObject> raindropList;

    public GameObject snowflake;
    public List<GameObject> snowflakeList;

    public Slider harshnessSlider;
    public TextMeshProUGUI seasonText;

    public int season; // 1 is Snow, 2 is Rain, 3 is Sandstorm

    void Start()
    {
        timeBetweenTimer = timeBetween;
        particleList = new List<GameObject>();
        raindropList = new List<GameObject>();
        snowflakeList = new List<GameObject>();
        seasonTimer = seasonLength;
        seasonText.text = "Snow";


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

            if (season == 1)
            {
                seasonText.text = "Snow";
                for (int i = 0; i < particleNumber * harshnessSlider.value; i++)
                {
                    GameObject newParticle = Instantiate(particle);
                    newParticle.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);

                    ParticleMovement size = newParticle.GetComponent<ParticleMovement>();
                    size.myTransform.localScale = new Vector3(harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f);

                    particleList.Add(newParticle);

                    



                }

                for (int i = 0; i < (particleNumber - 18) * harshnessSlider.value; i++)
                {
                    GameObject newSnowflake = Instantiate(snowflake);
                    newSnowflake.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);
                    snowflakeList.Add(newSnowflake);

                }

            } else if (season == 2)
            {
                seasonText.text = "Rain";
                for (int i = 0; i < particleNumber * harshnessSlider.value; i++)
                {
                    GameObject newRaindrop = Instantiate(raindrop);
                    newRaindrop.transform.position = new Vector3(Random.Range(-12, 10), 8, 0);
                    raindropList.Add(newRaindrop);

                }


            } else
            {
                seasonText.text = "Sandstorm";
                for (int i = 0; i < particleNumber * 2 * harshnessSlider.value; i++)
                {
                    GameObject newParticle = Instantiate(particle);
                    newParticle.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);
                    newParticle.GetComponent<Renderer>().material.color = Color.yellow;
                    particleList.Add(newParticle);

                    ParticleMovement size = newParticle.GetComponent<ParticleMovement>();
                    size.myTransform.localScale = new Vector3(harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f);

                }

            }

            

        }

    }

    public void SeasonChange()
    {
        harshnessSlider.value = Random.Range(0, 5);
        seasonTimer = seasonLength;

        if (season == 1)
        {
            
            for (int i = 0; i < particleList.Count; i++)
            {
                Destroy(particleList[i]);

            }

            for (int i = 0; i < snowflakeList.Count; i++)
            {
                Destroy(snowflakeList[i]);

            }

            particleList = new List<GameObject>();
            snowflakeList = new List<GameObject>();
        }
        else if (season == 2)
        {
            
            for (int i = 0; i < raindropList.Count; i++)
            {
                Destroy(raindropList[i]);

            }

            raindropList = new List<GameObject>();

        } else
        {
            
            for (int i = 0; i < particleList.Count; i++)
            {
                Destroy(particleList[i]);

            }
            particleList = new List<GameObject>();
        }

        season++;

        if (season > 3)
        {
            season = 1;
        }
    }
}
