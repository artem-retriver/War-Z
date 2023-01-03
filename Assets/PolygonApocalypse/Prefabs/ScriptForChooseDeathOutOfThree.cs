using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForChooseDeathOutOfThree : MonoBehaviour
{
    public List<GameObject> Death = new List<GameObject>();
    public int RightButton;
    public int ClickedButtonNum;
    public bool isItMonsterDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Action()
    {
        if(isItMonsterDoor == false)
        {
            if (ClickedButtonNum == RightButton)
            {
                Death[ClickedButtonNum].SetActive(true);
            }
        }
        else if(isItMonsterDoor == true)
        {
            if (ClickedButtonNum != RightButton)
            {
                Death[ClickedButtonNum].SetActive(true);
            }
        }
        
    }
    public void ClickedButtonSteUp(int num)
    {
        ClickedButtonNum = num;
    }
    public void RightButSetUp(int num)
    {
        RightButton = num;
    }
}
