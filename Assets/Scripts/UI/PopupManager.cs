using System;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField]
    private Popup[] popups;

    private Dictionary<PopupType, Popup> activePopups = new();

    [SerializeField] private Transform popupContainer;

    private void Start()
    {
        foreach (var popup in popups)
        {
            popup.Hide();
        }
    }

    public void AddPopup(PopupType type)
    {
        if (!activePopups.ContainsKey(type))
        {
            activePopups[type] = GetPopup(type);
        }
    }

    public void RemovePopup(PopupType type)
    {
        if (!activePopups.ContainsKey(type))
        {
            throw new Exception("Popup not found or already removed!");
        }

        activePopups[type].Hide();
        activePopups.Remove(type);
    }

    public void CloseAllPopups()
    {
        foreach (var popup in activePopups)
        {
            popup.Value.Hide();
        }
        activePopups.Clear();
    }

    private Popup GetPopup(PopupType type)
    {
        foreach(var popup in popups)
        {
            if (popup.PopupType == type)
            {
                return popup;
            }
        }

        return null;
    }
}
