using UnityEngine;

public class BarrelChanger : MonoBehaviour
{
    public Sprite[] arrayOfSprites;
    public SpriteRenderer sr;
    float timer = 0;
    public int timerLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        timer = 0;
        timerLength = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerLength)
        {
            timer = 0;
            ChangeBarrel();
        }
    }
    
    public void ChangeBarrel()
    {
        sr.sprite = arrayOfSprites[Random.Range(0, arrayOfSprites.Length)];
    }

    public void ChangeTimer()
    {
        timerLength = Random.Range(0, 6);
    }
}
