using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI inventaire;
    public TextMeshProUGUI vie;
    public Image wave;
    public Image tree;

    public void UpdateInventaire(int stuff)
    {
        inventaire.text = stuff + " / 10";
    }

    public void UpdateLife(int life)
    {
        vie.text = life + " / 3";
    }

    public void ActiveWaveWin()
    {
        wave.fillAmount = 1;
    }
    
    public void DeactiveWave()
    {
        wave.fillAmount = 0;
    }
    
    public void ActiveTreeWin()
    {
        tree.fillAmount = 1;
    }
    
    public void DeactiveTree()
    {
        tree.fillAmount = 0;
    }
}
