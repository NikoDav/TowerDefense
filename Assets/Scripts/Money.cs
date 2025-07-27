using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyText;
    public static Money Instance;

    private void Start()
    {
        Instance = this;
    }

    public bool SpendMoney(int money)
    {
        if (_money - money < 0)
        {

            return false;
        }
        _money -= money;
        _moneyText.text = "$" + _money;
        return true;
    }

    public void addMoney(int money)
    {
        _money += money;
        _moneyText.text = "$" + _money;
    }
}
