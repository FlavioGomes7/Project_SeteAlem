using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collectable : MonoBehaviour
{
    private bool isLookingItem;
    public int scissorItem;
    private Outline outlineItem;
    // Start is called before the first frame update
    void Start()
    {
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
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            scissorItem++;
            Destroy(gameObject);
        }
    }
    */
}
