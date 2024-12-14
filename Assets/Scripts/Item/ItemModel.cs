using UnityEngine;

[System.Serializable]
public class ItemModel
{
    [SerializeField]
    private int id;

    [SerializeField]
    private string name;

    [SerializeField]
    private float weight;

    [SerializeField]
    private ItemType type;

    public int Id => id;
    public string Name => name;
    public float Weight => weight;
    public ItemType Type => type;

    public ItemModel(int id, string name, float weight, ItemType type)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.weight = weight;
    }
}