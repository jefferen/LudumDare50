using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CloseApp : MonoBehaviour
{
    GameObject pauseMenu;

    private void Awake()
    {
         pauseMenu = FindInActiveObjectByTag("PauseMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CallingMenu();
        }
    }

    void CallingMenu()
    {
        pauseMenu?.SetActive(!pauseMenu.activeInHierarchy);
    }

    public static void CloseGame()
    {
        if(Application.platform != RuntimePlatform.WebGLPlayer) Application.Quit();
    }


    GameObject FindInActiveObjectByTag(string tag)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        return objs.FirstOrDefault(t => t.CompareTag(tag)).gameObject;
    }
}
