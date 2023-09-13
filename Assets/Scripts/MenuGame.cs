using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
public class MenuGame : MonoBehaviour
{
    public void PlayGame()
    {
        MyLoading.LoadLevel("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
