using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject player;
    public GameObject circle1;
    private SpriteRenderer circle1Sprite;
    public GameObject circle2;
    private SpriteRenderer circle2Sprite;


    public float healthBarCorrection;
    
    // Start is called before the first frame update
    void Start()
    {
        var health = player.GetComponent<Player>().hp;
        circle1Sprite = circle1.GetComponent<SpriteRenderer>();
        circle2Sprite = circle2.GetComponent<SpriteRenderer>();

        slider.minValue = 0;
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
        circle1Sprite.color = gradient.Evaluate(1f);
        circle2Sprite.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        var health = player.GetComponent<Player>().hp;

        if (health > 0)
        {
            slider.value = health;
        
            fill.color = gradient.Evaluate(slider.normalizedValue);
            circle1Sprite.color = gradient.Evaluate(slider.normalizedValue);
            circle2Sprite.color = gradient.Evaluate(slider.normalizedValue);
        }
       
        if (health <= 0)
        {
            slider.value = health;
        
            fill.color = gradient.Evaluate(slider.normalizedValue);
            circle1Sprite.color = Color.clear;
            circle2Sprite.color = Color.clear;
        }
        
        Vector3 monsterPosition = new Vector3(player.transform.position.x, player.transform.position.y + healthBarCorrection, player.transform.position.z);
        GetComponent<Transform>().position = monsterPosition;

    }
}
