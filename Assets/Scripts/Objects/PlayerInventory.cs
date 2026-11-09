using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

    public int capNumber { get; private set; } //Только этот скрипт может устанавливать и менять значение
    public int livesNumber { get; private set; }

    public static bool showTopUI;

    public UnityEvent<PlayerInventory> OnCapCollected;
    public UnityEvent<PlayerInventory> OnLiveCollected;

    public void capCollected()
    {
        capNumber++;
        OnCapCollected.Invoke(this);
        showTopUI = true;
    }

    public void liveCollected()
    {
        livesNumber++;
        OnLiveCollected.Invoke(this);
        showTopUI = true;
    }
}
