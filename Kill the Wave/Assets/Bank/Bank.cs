using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    public int CurrentBalance { get { return currentBalance; } }
    // Start is called before the first frame update

    private void Awake()
    {
        currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance<0)
        {
            ReloadScene();
        }
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
