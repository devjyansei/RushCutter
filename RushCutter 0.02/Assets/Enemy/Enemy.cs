using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward =50;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();

    }
    public void GainGold()
    {

        if (bank==null) 
        {
            return;
        }

        bank.Deposit(goldReward);

    }
    public void StealGold()
    {
        if (bank == null) { return; }

        bank.Withdraw(goldPenalty);
    }


}
