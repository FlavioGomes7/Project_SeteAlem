using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collectable : MonoBehaviour
{
    [SerializeField] public ItemModel itemScriptable;
    private bool isLookingItem;
    private Outline outlineItem;
    private Player_Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Inventory>();
        outlineItem = GetComponent<Outline>();
        outlineItem.OutlineWidth = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isLookingItem)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Press E");
                inventory.CollectedScissor();
                Destroy(gameObject);
            }
        }
    }
    public void OnMouseEnter()
    {
        outlineItem.OutlineWidth = 5.5f;
        isLookingItem = true;
    }
    public void OnMouseExit()
    {
        outlineItem.OutlineWidth = 0f;
        isLookingItem = false;
    }
    public string SaveTypeOfItem()
    {
        string typeItem = itemScriptable.GetNameItem();
        return typeItem;
    }
}
