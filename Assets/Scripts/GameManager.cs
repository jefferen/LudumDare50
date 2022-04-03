using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject LostMenu, WinMenu;

    [SerializeField]
    Vector2 WinInterVal;

    [SerializeField]
    UnityEvent Win, Lose;

    public void CheckAge(int age)
    {
        if (age >= WinInterVal.x && age <= WinInterVal.y)
        {
            GetServed();
            Win?.Invoke();
        }
        else
        {
            LostTheMuffin();
            Lose?.Invoke();
        }
    }

    void GetServed() //
    {
        WinMenu.SetActive(true);
    }

    void LostTheMuffin() // lose
    {
        LostMenu.SetActive(true);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) RestartLvl();
    }

    public static void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextLvl()
    {
        if(SceneManager.GetActiveScene().buildIndex == 6) LoadStartMenu(); // last lvl
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadLevel(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    public static void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
