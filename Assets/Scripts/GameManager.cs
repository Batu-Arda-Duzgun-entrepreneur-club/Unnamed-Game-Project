using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.PlasticSCM.Editor.WebApi;

public class GameManager : MonoBehaviour
{

    float CurrentBalance;

    public TextMeshProUGUI CurrentBalanceText;

    // Start is called before the first frame update
    void Start()
    {
        CurrentBalance = 5.0f;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBalance(float amount)
    {
        CurrentBalance += amount;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
    }

    public bool CanBuy(float amountToSpend)
    {
        if (CurrentBalance < amountToSpend)
        {
            Debug.Log("Failed to buy because");
            Debug.Log("Current balance: " + CurrentBalance.ToString());
            Debug.Log("Amount to spend: " + amountToSpend.ToString());

            return false;
        }
        else
        {
            Debug.Log("Successfully bought because");
            Debug.Log("Current balance: " + CurrentBalance.ToString());
            Debug.Log("Amount to spend: " + amountToSpend.ToString());

            return true;
        }
    }


}
