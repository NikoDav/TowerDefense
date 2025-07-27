using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextDrop : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private float _timeDrop;
    [SerializeField] private float _timeStay;
    [SerializeField] private RectTransform _rectTransform;
    private Vector2 _originalPosition;


    private void Start()
    {
        _originalPosition = _rectTransform.anchoredPosition;
    }
    [ContextMenu("Drop")]
    public void Drop()
    {
        Vector2 downPos = _originalPosition + Vector2.down * _offset;
        _rectTransform.DOAnchorPos(downPos, _timeDrop).SetEase(Ease.InQuad).OnComplete(() =>
        {
            DOVirtual.DelayedCall(_timeStay, () =>
            {
                _rectTransform.DOAnchorPos(_originalPosition, _timeDrop).SetEase(Ease.InQuad);
            });
        });
    }
}
