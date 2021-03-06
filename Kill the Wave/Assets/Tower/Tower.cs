using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tower : MonoBehaviour
{

    [SerializeField] int towerCost = 75;
    [SerializeField] TextMeshProUGUI towerCostDisplay;
    // Start is called before the first frame update

    private void Start()
    {
      //  towerCostDisplay.text = "Tower: " + towerCost + " G";
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
