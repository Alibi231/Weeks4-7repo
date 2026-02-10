using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed;
    public float startPoint;
    public float endPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;

        newPos.x += speed * Time.deltaTime;

        if (newPos.x > endPoint)
        {
            newPos.x = startPoint;
        }

        transform.position = newPos;
    }
}
