using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten : MonoBehaviour
{
    GameManager gameManager;
    Age Age;
    GameObject ReadyToEat;

    bool GottenHeat = false;

    private void Awake()
    {
        ReadyToEat = transform.GetChild(0).gameObject;
        Age = GameObject.FindGameObjectWithTag("Heat").GetComponent<Age>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update() // hard coded code
    {
        int Heat = Age.GetAge();
        if((Heat >= 68 && Heat <= 72))
        {
            if (ReadyToEat.activeInHierarchy) return;
            ReadyToEat.SetActive(true);
        }
        else if(ReadyToEat.activeInHierarchy)
        {
            ReadyToEat.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Triggered(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Triggered(collision);
    }

    void Triggered(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mouth"))
        {
            gameManager.CheckAge(Age.GetAge());
        }  
    }

    public void GetHeat(int heat)
    {
        if (GottenHeat) return;
        GottenHeat = true;
        Invoke("CanGetHeat", 2);
        Age.IncreaseAge(heat);
    }

    void CanGetHeat()
    {
        GottenHeat = false;
    }
}
