using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControler : MonoBehaviour
{
    private int playerHp;
    private Slider slider;
    public Text text;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>().vida;
        switch(playerHp)
        {
            case 1:
                text.text = "1";
                break;
            case 2:
                text.text = "2";
                break;
            case 3:
                text.text = "3";
                break;
            case 4:
                text.text = "4";
                break;
            case 5:
                text.text = "5";
                break;
        }
        slider.value = playerHp;
    }
}
