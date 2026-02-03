using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 10;
    public SpriteRenderer enemy;
    public Slider slider;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (enemy.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame){
            Attacked();
        }
    }

    public void Attacked()
    {
        health--;
        slider.value = health;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
