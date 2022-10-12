using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class Bank : MonoBehaviour
{

    [SerializeField] int startMoney;
    [SerializeField] int currentMoney;
    public int CurrentMoney{get{return currentMoney;}}
    private void Awake()
    {
        currentMoney = startMoney;
    }
    public void Deposit(int amount)
    {        
        currentMoney += Mathf.Abs(amount);
    }
    public void Withdraw(int amount)
    {
        currentMoney -= Mathf.Abs(amount);

        if (currentMoney < 0)
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
