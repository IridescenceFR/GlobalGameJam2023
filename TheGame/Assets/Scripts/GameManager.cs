using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public UIScript ui;
    private bool startEnd = false;
    private float cooldown = 3;

    public void OnWaveWin()
    {
        ui.ActiveWaveWin();
        startEnd = true;
    }

    public void OnMangroveWin()
    {
        ui.ActiveTreeWin();
        startEnd = true;
    }

    void Update()
    {
        if (startEnd)
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else
            {
                ui.DeactiveWave();
                ui.DeactiveTree();
                SceneManager.LoadScene(0);
            }
        }
    }
}
