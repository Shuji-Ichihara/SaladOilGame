using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // 実装するItemの種類
    {
        OilItem,
        GomaItem,
        
    }

    public Type type; // 種類
    public String infomation; // 情報

    public Item(Item item)
    {
        this.type = item.type;
        this.infomation = item.infomation;
    }
}