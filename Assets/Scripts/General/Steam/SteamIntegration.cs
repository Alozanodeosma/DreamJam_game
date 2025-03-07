using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(3363200);
            PrintName();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }
    

    private void PrintName()
    {
        Debug.Log("my name is: "+Steamworks.SteamClient.Name);
        foreach (var friend in Steamworks.SteamFriends.GetFriends())
        {
            Debug.Log("my friends are: "+friend);
        }
    }
}
