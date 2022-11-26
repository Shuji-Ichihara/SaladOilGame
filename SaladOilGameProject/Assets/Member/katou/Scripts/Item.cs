using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    public enum Type // ��������Item�̎��
    {
        OilItem,
        GomaItem,
        
    }

    public Type type; // ���
    public String infomation; // ���

    public Item(Item item)
    {
        this.type = item.type;
        this.infomation = item.infomation;
    }
}