using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public SpriteRenderer lifebar;
    public float life = 1;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        lifebar.size = new Vector2(life * 2.17f, 0.8f);

    }

    public void LowDamage()
    {
        life -= 0.1f;
        life = Mathf.Clamp01(life);
    }
}
