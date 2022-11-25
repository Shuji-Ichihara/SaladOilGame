using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // À‘•‚·‚éItem‚Ìí—Ş
    {
        OilItem,
        GomaItem,
        
    }

    public Type type; // í—Ş
    public String infomation; // î•ñ

    public Item(Item item)
    {
        this.type = item.type;
        this.infomation = item.infomation;
    }
}