using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public enum ItemType { Useable, Weapon, Armor }

[CreateAssetMenu(fileName = "New File", menuName ="Inventory/Item Data")]
public class ItemData_SO :ScriptableObject
{

  public ItemType itemType;

   public string itemName ;

   public Sprite itemIcon;

   public int itemAmount ;

   public string description = "";

    public bool stackable;

}
