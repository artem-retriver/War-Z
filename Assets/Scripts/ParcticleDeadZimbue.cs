using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcticleDeadZimbue : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] public List<ParticleSystem> particle;

    private void Update()
    {
        if (gameManager.zombie[0].hp <= 0)
        {
            particle[0].transform.position = gameManager.zombie[0].transform.position;
            particle[0].Play();
        }
    }
}
