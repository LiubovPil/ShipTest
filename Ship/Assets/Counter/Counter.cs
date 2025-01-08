using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShipTest;

public class Counter : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Text FinishText;
    public Text CounterText;
    public Text LifeText;
    public int startLife;

    private int Count = 0;
    private int Life = 0;

    private void Start()
    {
        Count = 0;
        Life = startLife;
        LifeText.text = "Life : " + Life;

        FinishText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Count += 1;
            CounterText.text = "Count : " + Count;
            other.gameObject.transform.SetParent(this.transform, true);
        }
        else if (other.gameObject.CompareTag("Bad"))
        {
            Life--;
            LifeText.text = "Life : " + Life;
            other.gameObject.transform.SetParent(this.transform, true);
        }


        if (Life == 0)
        {
            CounterText.gameObject.SetActive(false);
            LifeText.gameObject.SetActive(false);
            FinishText.gameObject.SetActive(true);
            spawnManager.Stop();
        }
    }
}
