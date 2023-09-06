using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//singleton
public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
    public SpriteRenderer lifebar;
    public float life = 1;
    public GameObject respawn;
    public GameObject playerprefab;
    GameObject playerinstance;
    public MyCamera mycamera;
    bool wait = false;

    // Use this for initialization
    void Start () {
        instance = this;
       
    }
	
	// Update is called once per frame
	void Update () {
       
        if (!playerinstance && !wait)
        {
            StartCoroutine(CreatePlayer());
        }

        if (playerinstance)
        {
            if(playerinstance.transform.position.y < mycamera.transform.position.y-6)
            {
                Destroy(playerinstance);
            }
        }
        
    }
    IEnumerator CreatePlayer()
    {
        wait = true;
        yield return new WaitForSeconds(2);
        mycamera.SetPlayer(respawn);
        yield return new WaitForSeconds(2);
        playerinstance = Instantiate(playerprefab, respawn.transform.position, Quaternion.identity);
        mycamera.SetPlayer(playerinstance);
        life = 1;
        lifebar.size = new Vector2(life * 2.17f, 0.8f);
        wait = false;
    }
    /// <summary>
    /// Aplica pouco dano
    /// </summary>
    public void LowDamage()
    {
        life -= 0.1f;
        life = Mathf.Clamp01(life);
        lifebar.size = new Vector2(life * 2.17f, 0.8f);
        if (life <= 0.01f)
        {
            Destroy(playerinstance);
        }
    }
}
