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

    //particle is made public so it can be assigned as a preset. The same goes for the raindrops and snowflakes below.
    public GameObject particle;
    public List<GameObject> particleList;

    public GameObject raindrop;
    public List<GameObject> raindropList;

    public GameObject snowflake;
    public List<GameObject> snowflakeList;

    //References to the harshnessSlider and the seasonText so they can be changed through the code, to meet assignment requirements. 
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

        //Season text is set to snow when the project starts, because the project will always be started with it snowing. 
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


        // Once the timer reaches zero, a new wave of objects is spawned based on the current season.
        if (timeBetweenTimer < 0)
        {
            // Resets the timer length.
            timeBetweenTimer = timeBetween;

            if (season == 1)
            {
                // During the first season, the snow text is displayed, and a wave of particles are instantiated.
                seasonText.text = "Snow";
                for (int i = 0; i < particleNumber * harshnessSlider.value; i++)
                {
                    GameObject newParticle = Instantiate(particle);
                    newParticle.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);

                    //Particles are sized using a getComponent reference, and is changed based on the harshness slider variable.
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
                // During the second season, the rain text is displayed, and a wave of raindrops are instantiated.
                seasonText.text = "Rain";
                for (int i = 0; i < particleNumber * harshnessSlider.value; i++)
                {
                    GameObject newRaindrop = Instantiate(raindrop);
                    newRaindrop.transform.position = new Vector3(Random.Range(-12, 10), 8, 0);
                    raindropList.Add(newRaindrop);

                }


            } else
            {
                // During the first season, the sandstorm text is displayed, and a wave of particles are instantiated.
                seasonText.text = "Sandstorm";
                for (int i = 0; i < particleNumber * 2 * harshnessSlider.value; i++)
                {
                    GameObject newParticle = Instantiate(particle);
                    newParticle.transform.position = new Vector3(-10, Random.Range(yRangeMin, yRangeMax), 0);
                    newParticle.GetComponent<Renderer>().material.color = Color.yellow;
                    particleList.Add(newParticle);

                    //Particles are sized using a getComponent reference, and is changed based on the harshness slider variable.
                    ParticleMovement size = newParticle.GetComponent<ParticleMovement>();
                    size.myTransform.localScale = new Vector3(harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f, harshnessSlider.value * 0.05f);

                }

            }

            

        }

    }

    public void SeasonChange()
    {
        // When the season changes, the season timer is reset, and the sliders value is set to a random number.
        harshnessSlider.value = Random.Range(0, 5);
        seasonTimer = seasonLength;

        // When the season changes depending on the season, every gameObject in the list is destroyed, then the list is set to being empty.
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

        //If the season is out of bounds, it will be set to the initial season.
        if (season > 3)
        {
            season = 1;
        }
    }
}
