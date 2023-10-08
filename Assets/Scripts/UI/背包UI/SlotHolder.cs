using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SlotType { BAG, WEAPON, ARMOR, ACTION }

public class SlotHolder : MonoBehaviour, IPointerClickHandler
{
  


    public SlotType slotType;

    public ItemUI itemUI;

/*    public Image icon;*/

   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount % 2 == 0)
        {
            ItemType type= itemUI.Bag.items[itemUI.Index].ItemData_SO.itemType;
            
            switch (type) {
                case ItemType.Weapon:


                    foreach (SlotHolder slot in ContainerUI.Instance.slotHolders)
                    {
                        if (slot.slotType == SlotType.WEAPON)
                        {

                            slot.itemUI.icon.sprite = itemUI.icon.sprite;
                            slot.itemUI.icon.gameObject.SetActive(true);
                        }


                    }
                    //PlayerControl.Instance.isweapon = true;
                    
                    break;
                case ItemType.Useable:
                    foreach (SlotHolder slot in ContainerUI.Instance.slotHolders) {
                        if (slot.slotType == SlotType.ACTION) {
                            slot.itemUI.icon.gameObject.SetActive(true);
                            slot.itemUI.icon.sprite = itemUI.icon.sprite;
                            
                        }
                    
                    
                    }
             
                    //PlayerControl.Instance.ishp = true;
                    break;
                case ItemType.Armor:

                    break;

            }
           
            UseItem();
        }

    }



    void UseItem() {

        /*        icon.sprite = itemUI.icon.sprite;
                icon.gameObject.SetActive(true);*/
        UpdateItem();
        itemUI.icon.gameObject.SetActive(false);
        itemUI.Bag.items.Remove(itemUI.Bag.items[itemUI.Index]);


    }



    public void UpdateItem() {
        switch (slotType)
        {
            case SlotType.BAG:
                itemUI.Bag = InventoryManager.Instance.InventoryData;
                itemUI.SetupItemUI(itemUI.Bag.items[itemUI.Index].ItemData_SO, itemUI.Bag.items[itemUI.Index].ItemAmount);
                break;
            case SlotType.WEAPON:
               
             /*   itemUI.WEAPON= InventoryManager.Instance.equipmentData;
                itemUI.SetupItemUI(itemUI.WEAPON.items[itemUI.Index].ItemData_SO, itemUI.WEAPON.items[itemUI.Index].ItemAmount);*/
                if (itemUI.Bag.items[itemUI.Index].ItemData_SO != null)
                {
                  /*  GameManager.Instance.playerStats.Changeweapon(itemUI.Bag.items[itemUI.Index].ItemData_SO);*/
                }
                else
                {
                    /*GameManager.Instance.playerStats.UnEquipweapon();*/
                }
                break;
            case SlotType.ARMOR:
                break;
            case SlotType.ACTION:
                break;
        }

/*        var item = itemUI.Bag.items[itemUI.Index];
        itemUI.SetupItemUI(item.ItemData_SO, item.ItemAmount);*/
    }
}

