using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearbarNun1 : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject NPC;
    public GameObject circle1;
    private SpriteRenderer circle1Sprite;
    public GameObject circle2;
    private SpriteRenderer circle2Sprite;


    public float healthBarCorrection;
    
    // Start is called before the first frame update
    void Start()
    {
        var fear = NPC.GetComponent<Nun1>().fear;
        circle1Sprite = circle1.GetComponent<SpriteRenderer>();
        circle2Sprite = circle2.GetComponent<SpriteRenderer>();

        slider.minValue = 0;
        slider.maxValue = NPC.GetComponent<Nun1>().fearLimit;
        slider.value = fear;

        fill.color = gradient.Evaluate(1f);
        circle1Sprite.color = gradient.Evaluate(1f);
        circle2Sprite.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (NPC == null) 
        {
            Destroy(gameObject);
        }
        else
        {
            var fear = NPC.GetComponent<Nun1>().fear;

            if (fear > 0)
            {
                slider.value = fear;

                fill.color = gradient.Evaluate(slider.normalizedValue);
                circle1Sprite.color = gradient.Evaluate(slider.normalizedValue);
                circle2Sprite.color = gradient.Evaluate(slider.normalizedValue);
            }

            if (fear <= 0)
            {
                slider.value = fear;

                fill.color = gradient.Evaluate(slider.normalizedValue);
                circle1Sprite.color = Color.clear;
                circle2Sprite.color = Color.clear;
            }

            Vector3 monsterPosition = new Vector3(NPC.transform.position.x,
                NPC.transform.position.y + healthBarCorrection, NPC.transform.position.z);
            GetComponent<Transform>().position = monsterPosition;
        }
    }
}