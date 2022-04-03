using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Age : MonoBehaviour
{
    TMPro.TextMeshProUGUI AgeText;

    [SerializeField]
    Gradient OptimalDeath;

    [SerializeField]
    int SetAge = 50;

    int _age;
    int age
    {
        get => _age;
        set
        {
            _age = value;
            if(value < 0) _age = 0;
            AgeText.color = OptimalDeath.Evaluate(age/100f);
            AgeText.text = age.ToString(); 
        }
    }

    private void Awake()
    {
        AgeText = GetComponent<TMPro.TextMeshProUGUI>();
        InvokeRepeating("IncreaseAge", 0, 1);
        age = SetAge;
    }

    void IncreaseAge()
    {
        ++age;
    }

    public void IncreaseAge(int year)
    {
        age += year;
    }

    public int GetAge()
    {
        return age;
    }
}
