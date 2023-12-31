using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ItemSlot
{
    public Items item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    public ItemSlot selectedItem;
    public int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDiscription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;
    public GameObject useButton;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        ClearSelectedItemWindow();
    }
    public void Toggle()
    {
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
            onCloseInventory?.Invoke();
        }
        else
        {
            inventoryWindow.SetActive(true);
            onOpenInventory?.Invoke();
        }
    }
    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }
    public void AddItem(Items item)
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if (slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }

            ItemSlot emptySlot = GetEmptySlot();

            if (emptySlot != null)
            {
                emptySlot.item = item;
                emptySlot.quantity = 1;
                UpdateUI();
                return;
            }

            ThrowItem(item);
        }
    }
    void ThrowItem(Items item)
    {
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector2.one * UnityEngine.Random.value * 360f));
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].quantity != 0)
            {
                uiSlots[i].Set(slots[i]);
            }
            else
                uiSlots[i].Clear();
        }
    }
    ItemSlot GetItemStack(Items item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
            {
                return slots[i];
            }
        }

        return null;
    }
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }
    public void SelectItem(int index)
    {
        if (slots[index].quantity == 0)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDiscription.text = selectedItem.item.description;

        selectedItemStatNames.text = string.Empty;
        selectedItemStatValues.text = string.Empty;

        useButton.SetActive(true);
    }
    private void ClearSelectedItemWindow()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDiscription.text = string.Empty;

        selectedItemStatNames.text = string.Empty;
        selectedItemStatValues.text = string.Empty;

        useButton.SetActive(false);
    }
    public void ClearSlot(int index)
    {
        slots[index].item = null;
        slots[index].quantity = 0;
        uiSlots[index].Clear();
    }
}
