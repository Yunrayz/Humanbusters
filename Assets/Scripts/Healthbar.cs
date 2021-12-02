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
    
    // Start is called before the first frame update
    void Start()
    {
        var health = player.GetComponent<Player>().hp;

        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        var health = player.GetComponent<Player>().hp;
        slider.value = health;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
