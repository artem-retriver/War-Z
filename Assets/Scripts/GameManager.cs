using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Zombie> zombie = new();
    public PlayerController playerController;
    

    private void Update()
    {
        for (int i = 0; i < zombie.Count; i++)
        {
            if (zombie[i].hp <= 0)
            {
                zombie.RemoveAt(i);
                playerController.isFight = false;
            }
        }
    }
}
