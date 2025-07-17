using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyText;

    public void SpendMoney(int money)
    {
        _money -= money;
        if (_money - money >= 0)
        {
            _money = 0;
        }
        _moneyText.text = "$" + _money;
    }

    public void addMoney(int money)
    {
        _money += money;
        _moneyText.text = "$" + _money;
    }
}
