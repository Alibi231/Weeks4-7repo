using UnityEngine;
using UnityEngine.InputSystem;

public class UIDemo : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        sr.color = Random.ColorHSV();
    }
    
    public void SetScale(int size)
    {
        gameObject.transform.localScale = new Vector3 (size, size, size);
    }
}
