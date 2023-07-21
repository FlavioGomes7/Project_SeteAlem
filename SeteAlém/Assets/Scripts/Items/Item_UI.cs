using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scissorsText;
    // Start is called before the first frame update
    void Start()
    {
        scissorsText = GetComponent<TextMeshProUGUI>();
        scissorsText.text = "Scissors: 0";
    }
    public void UpdateDiamondText(Player_Inventory playerInventory)
    {

        scissorsText.text = "Scissors: " + playerInventory.NumberOfScissors.ToString();



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
