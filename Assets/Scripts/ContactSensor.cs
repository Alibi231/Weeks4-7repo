using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    
    public SpriteRenderer hazard;
    public bool inHazard = false;
    public UnityEvent OnTrapEntered;
    public UnityEvent OnTrapExited;
    public UnityEvent<float> OnRandomNumber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player in hazard, set inHazard == true;
        if (hazard.bounds.Contains(transform.position))
        {
            if (!inHazard)
            {
                inHazard = true;
                Debug.Log("H ENTERED");
                OnTrapEntered.Invoke();
                OnRandomNumber.Invoke(Random.Range(1,5));
            }

        }
        else
        {
            if (inHazard)
            {
                inHazard = false;
                Debug.Log("H LEFT");
                OnTrapExited.Invoke();

            }
        }
    }
}
