using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform controller;
    //[SerializeField] private Transform camController;
    [SerializeField] private GameManager gameManager;
    public Rigidbody rb;
    public AnimationController animController;
    //[SerializeField] private Slider slider;

    public List<ParticleSystem> particle;
    [SerializeField] private GameObject aliveBody;
    [SerializeField] private GameObject deadBody;

    [SerializeField] private float speed;
    public int hp;
    public int damage;

    public bool isPlayer;
    public float time = 4;

    Vector3 newPos;

    private void Start()
    {
        deadBody.SetActive(false);
    }

    private void Update()
    {
        //slider.value = hp;
        //slider.transform.LookAt(camController, Vector3.up);

        if(hp > 0)
        {
            newPos = new Vector3(controller.transform.position.x + 2f, controller.transform.position.y, controller.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

            transform.LookAt(controller, Vector3.up);
        }
        else if(hp <= 0)
        {
            particle[0].Stop();
            aliveBody.SetActive(false);
            deadBody.SetActive(true);
            CancelInvoke();
            animController.SetDeathTrigger();
            newPos = new Vector3(transform.position.x, 0, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPos, 0.2f);

            //if(transform.position.y <= 0)
            //{
            
            StartCoroutine(DeathZombie());
            //}   
        }

        if(isPlayer == true)
        {
            animController.SetPunchTrigger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController _))
        {
            isPlayer = true;

            if(isPlayer == true)
            {
                animController.SetPunchTrigger();
                InvokeRepeating(nameof(DamagePlayer), 1, time);
            }
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController _))
        {
            animController.SetPunchTrigger();
            InvokeRepeating(nameof(DamagePlayer), 3, 2);
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController _))
        {
            isPlayer = false;

            CancelInvoke();
            animController.SetRunTrigger();
        }
    }

    /*IEnumerator PunchZombie()
    {
        yield return new WaitForSeconds(1f);
        DamagePlayer();
    }*/

    IEnumerator DeathZombie()
    {
        yield return new WaitForSeconds(25f);

        
        Destroy(gameObject);
        
    }

    public void DamagePlayer()
    {
        particle[0].Play();
        gameManager.playerController.animController.SetHitTrigger();
        gameManager.playerController.hp -= damage;
    }
}
