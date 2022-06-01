using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Inventory.Equipped;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRenderInventory : IDisposable
{
    private IInventory Inventory { get;  }
    private UISlot[] _uiSlots;
    
    public UIRenderInventory(IInventory inventory, UISlot[] slots)
    {
        Inventory = inventory;
        _uiSlots = slots;
        
        InventoryEventManager.StateChanged += OnStateChanged;
        SetupInventoryUI(Inventory);
    }
    private void OnStateChanged()
    {
        foreach (var slot in _uiSlots)
        {
            slot.Refresh();
        }
    }
    private void SetupInventoryUI(IInventory inventory)
    {
        if (inventory == null)
            return;
        
        var allSlots = inventory.SlotSorter.GetAllSlots();
        for (var i = 0; i < allSlots.Length; i++)
        {
            _uiSlots[i].SetSlot(allSlots[i]);
            _uiSlots[i].Refresh();
        }
    }
    public void Dispose()
    {
        InventoryEventManager.StateChanged -= OnStateChanged;
    }
}
