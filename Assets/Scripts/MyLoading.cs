using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyLoading : MonoBehaviour
{
    AsyncOperation operation;
    static string level;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {

        operation = SceneManager.LoadSceneAsync(level);
        operation.allowSceneActivation = false;
        Invoke("AllowScene", 2);
    }

    void AllowScene()
    {
        operation.allowSceneActivation = true;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, operation.progress,Time.deltaTime*5);
    }
    /// <summary>
    /// Call this to load a level instead of SceneManager
    /// </summary>
    /// <param name="nextlevel"></param>
    public static void LoadLevel(string nextlevel)
    {
        level = nextlevel;
        SceneManager.LoadScene("Loading");
    }
}
