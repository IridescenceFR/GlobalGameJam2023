using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI inventaire;

    public void UpdateInventaire(int stuff)
    {
        inventaire.text = stuff + " / 10";
    }
}
