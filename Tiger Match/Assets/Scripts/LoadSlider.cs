using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSlider : MonoBehaviour
{

    private Slider slider;

    [SerializeField] private GameObject panelLoad;

    private float stepMax = 0.01f;
    private float stepMin = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        addValueSlider();

        if (slider.value >= 1f)
        {
            Destroy(panelLoad);
        }

    }

    private void addValueSlider()
    {
        float r_step = Random.Range(stepMin, stepMax);
        slider.value += r_step * Time.deltaTime;
    }



}
