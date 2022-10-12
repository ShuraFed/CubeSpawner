using System;
using TMPro;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private TMP_InputField speedInput;
    private TMP_InputField distanceInput;

    private float speed;
    private float distance;
    private float time;

    private void Awake()
    {
        OnCreate();
    }

    private void OnEnable()
    {
        OnSpawn();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void Reset()
    {
        transform.localPosition=Vector3.zero;
    }

    public void OnCreate()
    {
        speedInput = GameObject.Find("Speed").GetComponent<TMP_InputField>();
        distanceInput = GameObject.Find("Distance").GetComponent<TMP_InputField>();
    }

    public void OnSpawn()
    {
        float.TryParse(speedInput.text, out speed);
        float.TryParse(distanceInput.text, out distance);
        if (Math.Abs(speed) < 0.01) gameObject.SetActive(false);
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (speed*time>=distance)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
