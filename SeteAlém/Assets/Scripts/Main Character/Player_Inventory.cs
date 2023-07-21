using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player_Inventory : MonoBehaviour
{
    public UnityEvent<Player_Inventory> OnScissorsCollected;
    public int NumberOfScissors {get; private set;}
    public void CollectedScissor()
    {
        NumberOfScissors++;
        OnScissorsCollected.Invoke(this);
    }
}
