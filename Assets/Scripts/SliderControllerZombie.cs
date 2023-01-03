using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerZombie : MonoBehaviour
{
    [SerializeField] private Transform camController;
    [SerializeField] private Zombie zombie;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = zombie.hp;
        slider.transform.LookAt(camController, Vector3.up);
    }
}
