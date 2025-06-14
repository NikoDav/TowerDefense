using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMultiSelection : MonoBehaviour
{
    private Vector2 _startPos;
    private Vector2 _endPos;
    private bool _isSelecting;
    private List<UnitControl> _unitsSelected;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
            _isSelecting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isSelecting = false;
        }
        if (_isSelecting)
        {
            _endPos = Input.mousePosition;
        }
    }

    private void OnGUI()
    {
        if (_isSelecting)
        {
            Rect rect = GetScreenRect(_startPos, _endPos);
            DrawScreenRect(rect, new Color(1, 0, 0, 0.3f));
            DrawScreenRectBorder(rect, new Color(1, 0, 0), 4);
        }
    }

    private void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, Texture2D.whiteTexture);
        GUI.color = Color.white;
    }

    private void DrawScreenRectBorder(Rect rect, Color color, float thickness)
    {
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        DrawScreenRect(new Rect(rect.xMin, rect.yMax-thickness, rect.width, thickness), color);
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        DrawScreenRect(new Rect(rect.xMax-thickness, rect.yMin, thickness, rect.height), color);
    }

    private Rect GetScreenRect(Vector2 a, Vector2 b)
    {
        return new Rect(Mathf.Min(a.x, b.x), Screen.height - Mathf.Max(a.y, b.y), Mathf.Abs(a.x - b.x), Mathf.Abs(a.y - b.y));
    }
}
