using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Transform camController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = playerController.hp;
        slider.transform.LookAt(camController, Vector3.up);
    }
}
