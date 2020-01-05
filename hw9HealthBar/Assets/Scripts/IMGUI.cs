using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGUI : MonoBehaviour
{
    
	public float showHP;
	public float HP;

	public Rect HealthBar;
	public Rect HealthUp;
	public Rect HealthDown;

	public Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {   
        showHP = 0.1f;
        HP = 0.1f;

        HealthBar = new Rect(25,25,300,50);
        HealthUp = new Rect(50,50,50,30);
        HealthDown = new Rect(100,50,50,30);
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(HealthUp, "加血"))
        {
            HP = HP + 0.1f > 1.0f ? 1.0f : HP + 0.1f;
        }
        if (GUI.Button(HealthDown, "减血"))
        {
            HP = HP - 0.1f < 0.0f ? 0.0f : HP -0.1f;
        }

        showHP = Mathf.Lerp(showHP, HP,0.05f);
        GUI.HorizontalScrollbar(HealthBar, 0.0f, showHP, 0.0f,1.0f);
        HealthSlider.value = showHP;
    }
}
