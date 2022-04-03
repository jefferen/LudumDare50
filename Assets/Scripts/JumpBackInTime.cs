using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JumpBackInTime : MonoBehaviour
{
    [SerializeField]
    List<GameObject> jumpBack = new List<GameObject>();

    [SerializeField]
    public List<Vector2> jumpBackList;

    public int FrameCount;

    bool CanJumpBack = true;

    [SerializeField]
    Age age;

    void Awake()
    {
        age = GameObject.FindGameObjectWithTag("Heat").GetComponent<Age>();
        List<GameObject> Temp = new List<GameObject>();
        foreach (var item in jumpBack)  // red, orange, yellow, green, black
        {
            Temp.Add(Instantiate(item, transform.position, Quaternion.identity));
        }

        jumpBack = Temp;
        jumpBackList = new List<Vector2>();
    }

    void Update()
    {
        if (!CanJumpBack) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HideJumpBacks(3, -1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HideJumpBacks(2,-2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HideJumpBacks(1,-3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HideJumpBacks(0,-4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            HideJumpBacks(4,-5);
        }
    }

    void HideJumpBacks(int jumpingBack, int ageDecrease)
    {
        transform.position = jumpBack[jumpingBack].transform.position;
        age.IncreaseAge(ageDecrease);

        CanJumpBack = false;
        foreach (var item in jumpBack)
        {
            item.SetActive(false);
        }
        Invoke("ShowJumpBacks", 1.5f);
    }

    void ShowJumpBacks()
    {
        CanJumpBack = true;
        foreach (var item in jumpBack)
        {
            item.SetActive(true);
        }
    }

    void GetTransform()
    {
        var currentTransform = transform.position;
        jumpBackList.Add(currentTransform);

        while (jumpBackList.Count >= FrameCount)
        {
            jumpBackList.RemoveAt(0);
        }
        UpdateJumpBack();
    }

    private void FixedUpdate() // calling every fixed update which is called at a fixed rate
    {
        if (jumpBack.Count == 0) return;
        GetTransform();
    }

    void UpdateJumpBack()
    {
        int amount = FrameCount / 5;
        int amount2 = amount * 2;
        int amount3 = amount * 3;
        int amount4 = amount * 4;
        int amount5 = amount * 5;

        if (jumpBackList.Count >= amount)
        {
            jumpBack[0].transform.position = jumpBackList[amount - 1];
        }

        if (jumpBackList.Count >= amount2)
        {
            jumpBack[1].transform.position = jumpBackList[amount2 - 1];
        }
        if (jumpBackList.Count >= amount3)
        {
            jumpBack[2].transform.position = jumpBackList[amount3 - 1];
        }
        if (jumpBackList.Count >= amount4)
        {
            jumpBack[3].transform.position = jumpBackList[amount4 - 1];
        }
        if (jumpBackList.Count +1 >= amount5)
        {
            jumpBack[4].transform.position = jumpBackList[0];
        }
    }
}
