using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item - ", menuName = "Items", order = 1)]
public class ItemModel : ScriptableObject
{
    [SerializeField] private int idItem;
    [SerializeField] private string nameItem;
    public int GetIdItem()
    {
        return idItem;
    }
    public string GetNameItem()
    {
        return nameItem;
    }

}
