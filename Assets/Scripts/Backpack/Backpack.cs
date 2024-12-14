using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Backpack : MonoBehaviour
{
    public UnityEvent<Item> OnInsertItem;
    public UnityEvent<Item> OnExtractItem;
}
