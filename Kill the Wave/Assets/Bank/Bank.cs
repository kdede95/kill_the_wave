using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;


    [SerializeField] TextMeshProUGUI displayBalance;
   // [SerializeField] TextMeshProUGUI towerCost;
    public int CurrentBalance { get { return currentBalance; } }
    // Start is called before the first frame update

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        // towerCost.text = amount.ToString();
        if (currentBalance<0)
        {
            ReloadScene();
        }
        

    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
