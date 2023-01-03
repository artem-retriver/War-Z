using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public AnimationController animController;
    [SerializeField] private GameManager gameManager;
    public List<ParticleSystem> particle;

    public int damage;
    public int hp;

    [SerializeField] private MoveController moveController;
    //[SerializeField] private Transform zombie;

    public bool isFight;

    private void Start()
    {
        animController.SetIdletrigger();
    }

    private void Update()
    {
        if (isFight == false)
        {
            particle[0].Stop();
            particle[1].Stop();

            if (moveController.isRun == true)
            {
                animController.SetRunTrigger();
            }
            else
            {
                animController.SetIdletrigger();
            }
        }

        if(isFight == true)
        {
            //transform.LookAt(zombie, Vector3.up);
            animController.SetPunchTrigger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Zombie _))
        {
            isFight = true;
            
            if(isFight == true)
            {
                animController.SetPunchTrigger();
                InvokeRepeating(nameof(DamageZombie), 1, 1.4f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Zombie _))
        {
            isFight = false;
            CancelInvoke();
        }
    }

    public void DamageZombie()
    {
        particle[0].Play();
        particle[1].Play();

        gameManager.zombie[0].animController.SetHitTrigger();
        gameManager.zombie[0].hp -= damage;
    }
}
