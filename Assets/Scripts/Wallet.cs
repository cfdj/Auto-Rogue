using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Wallet manages paying for things and getting money as a reward from adventures
 * At present it handles its own display updating
*/
public class Wallet : MonoBehaviour
{
    public static Wallet wallet; //Singleton pattern
    public Text moneyDisplay;
    [SerializeField]
    private int money = 5;
    void Start()
    {
        updateDisplay();
        if(wallet == null)
        {
            wallet = this;
        }
        else if(wallet != this){
            Destroy(this);
        }
    }

    public bool checkMoney(int cost)
    {
        if (cost > money)
        {
            return false;
        }
        return true;
    }
    public void giveMoney(int amount)
    {
        money += amount;
        updateDisplay();
    }
    public void spendMoney(int amount)
    {
        money -= amount;
        updateDisplay();
    }

    void updateDisplay()
    {
        moneyDisplay.text = money+"";
    }
    
}
