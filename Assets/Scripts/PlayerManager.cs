using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Keybindings keybindings;

    public void SetCursorState(CursorLockMode wantedMode)
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        SetCursorState(CursorLockMode.Locked);
    }

    public GameObject player;

    public bool KeyDown(string key)
    {
        if (Input.GetKeyDown(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool KeyUp(string key)
    {
        if (Input.GetKeyUp(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
