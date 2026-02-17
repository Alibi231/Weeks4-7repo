using UnityEngine;

public class RaindropMovement : MonoBehaviour
{
    //All of the components relating to the particles movements are made public variables so they are easy to access and tweak.
    public float speed;
    public float speedMax;
    public float speedMin;
    public float driftSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The speed of the particles are randomized to give the illusion of a snow/sand storm.
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        // The particle is moved to the right by its driftspeed and downwards by speed.
        Vector2 newPos = transform.position;
        newPos.x += driftSpeed * Time.deltaTime;
        newPos.y += speed * Time.deltaTime;
        transform.position = newPos;
    }
}
