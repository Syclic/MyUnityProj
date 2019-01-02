using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public GameObject[] spellbook;
    public float[] spellbookCDs;
    Inventory inventory;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        spellbook = new GameObject[12];
        spellbookCDs = new float[12];
    }
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }
    public void Attune(Attunement newAttunement)
    {
        int slotIndex = (int)newAttunement.equipSlot;

        Attunement oldItem = null;

        currentEquipment[slotIndex] = newAttunement;
        spellbook[(slotIndex - 5) * 2] = newAttunement.ability1;
        spellbook[((slotIndex - 5) * 2) + 1] = newAttunement.ability2;
        spellbookCDs[(slotIndex - 5) * 2] = 0;
        spellbookCDs[((slotIndex - 5) * 2) + 1] = 0;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newAttunement, oldItem);
        }

    }

    public void Unequip(int slotIndex)
    {
        Equipment oldItem = currentEquipment[slotIndex];
        inventory.Add(oldItem);
        currentEquipment[slotIndex] = null;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, oldItem);
        }
    }
    public void UnequipAll()
    {
        for(int i = 0; i < 5; i++)
        {
            Unequip(i);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
        for (int i = 0; i < 12; i++)
        {
            if(spellbook[i] != null && spellbookCDs[i] > 0)
            {
                spellbookCDs[i] -= Time.deltaTime;
            }
        }
    }
}
