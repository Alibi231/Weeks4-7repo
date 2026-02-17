using UnityEngine;


public class ParticleMovement : MonoBehaviour
{
    //All of the components relating to the particles movements are made public variables so they are easy to access and tweak.
    public float speed;
    public float speedMax;
    public float speedMin;
    public float fallSpeed;
    public Transform myTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        // The speed of the particles are randomized to give the illusion of a snow/sand storm.
        speed = Random.Range(speedMin, speedMax);

        // This assigns myTransform to the transform component of the object. This is so it can be referenced in the particleSpawnerScript.
        myTransform = transform.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // The particle is moved to the right by its speed and downwards by a fallSpeed to simulate gravity.
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        newPos.y += fallSpeed * Time.deltaTime;
        transform.position = newPos;

        //Rotates the object. This is used because this script is also used to rotate the snowflake, even if it is innefective on particles.
        Vector3 newRot = transform.eulerAngles;
        newRot.z += 10 * Time.deltaTime;
        transform.eulerAngles = newRot;
    }
}
