using System.Collections;
using TMPro;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public TMP_InputField TimeBetweenSpawnsInput;

    private float seconds;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            var go = ObjectPool.SharedInstance.GetPooledObject();
            if (go!=null)
            {
                go.SetActive(true);
            }
            float.TryParse(TimeBetweenSpawnsInput.text,out seconds);
            yield return new WaitForSeconds(seconds);
        }
    }
}
