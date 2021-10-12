using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Tower : MonoBehaviour
{

    [SerializeField] int towerCost = 75;
    [SerializeField] TextMeshProUGUI towerCostDisplay;
    [SerializeField] float buildDelay = 1.5f;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }

    public bool CreateTower(Tower tower,Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank==null)
        {
            return false;
        }

        if (bank.CurrentBalance>=towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            
            bank.Withdraw(towerCost);
            
            return true;


        }


        return false;
    }
}
