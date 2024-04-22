using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;




public class Store : MonoBehaviour
{

    int StoreCount;

    public GameManager gameManager;
    public TextMeshProUGUI StoreCountText;
    public TextMeshProUGUI BuyStoretext;
    public Slider ProgressSlider;

    [SerializeField] float BaseStoreCost;
    [SerializeField] float BaseStoreProfit;


    float StoreTimer = 2f;
    float CurrentTimer = 0f;
    float CostIncreaseRate = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        StoreCount = 0;
        StoreCountText.text = StoreCount.ToString();

        BuyStoretext.text = "Buy " + (BaseStoreCost * Mathf.Pow(CostIncreaseRate, (StoreCount))).ToString("C2");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer += Time.deltaTime;
        if (CurrentTimer > StoreTimer)
        {
            CurrentTimer = 0f;
            gameManager.AddToBalance(BaseStoreProfit * StoreCount);
            

        }
        if (StoreCount > 0)
        {
            ProgressSlider.value = CurrentTimer / StoreTimer;
        }
        
    }

    public void BuyStoreOnClick()
    {
        if (!gameManager.CanBuy((BaseStoreCost * Mathf.Pow(CostIncreaseRate, (StoreCount )))))
      
            return;
        
        gameManager.AddToBalance(-(BaseStoreCost * Mathf.Pow(CostIncreaseRate, (StoreCount))));

        StoreCount += 1;
        StoreCountText.text = StoreCount.ToString();
        BuyStoretext.text = "Buy " + (BaseStoreCost * Mathf.Pow(CostIncreaseRate, (StoreCount))).ToString("C2");
    }

}
 