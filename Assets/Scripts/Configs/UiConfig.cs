using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UiConfig", menuName = "ScriptableObjects/UiConfig", order = 2)]
public class UiConfig : ScriptableObject
{
    [SerializeField]
    ItemUi ball;
    [SerializeField]
    ItemUi bread;
    [SerializeField]
    ItemUi water;

    public ItemUi Ball => ball;
    public ItemUi Bread => bread;
    public ItemUi Water => water;
}