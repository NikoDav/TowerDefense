using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTowerUI : MonoBehaviour
{
    [SerializeField] private GameObject _unit;
    [SerializeField] private Button _button;
    [SerializeField] private Image _lockImage;
    [SerializeField] private TMP_Text _label;

    public GameObject Unit { get => _unit; set => _unit = value; }

    public void SetInetractable(bool isActive)
    {
        if (isActive)
        {
            _lockImage.gameObject.SetActive(false);
            _label.gameObject.SetActive(false);
            _button.interactable = true;
        }
        else
        {
            _lockImage.gameObject.SetActive(true);
            _label.gameObject.SetActive(true);
            _button.interactable = false;
        }
    }
}
