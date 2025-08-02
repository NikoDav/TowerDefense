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
#if UNITY_EDITOR
        _money = 10000000;
#else
        _money = 400;
#endif
        _moneyText.text = "$" + _money;
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
