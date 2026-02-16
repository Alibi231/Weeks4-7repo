using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    //All of the components relating to the particles movements are made public variables so they are easy to access and tweak.
    public float speed;
    public float speedMax;
    public float speedMin;
    public float fallSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The speed of the particles are randomized to give the illusion of a snow/sand storm.
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        // The particle is moved to the right by its speed and downwards by a fallSpeed to simulate gravity.
        Vector2 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        newPos.y += fallSpeed * Time.deltaTime;
        transform.position = newPos;
    }
}
