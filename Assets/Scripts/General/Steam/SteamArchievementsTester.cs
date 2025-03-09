using System;
using Steamworks;
using Steamworks.Data;
//using Unity.Android.Gradle.Manifest;
using UnityEngine;

namespace General.Steam
{
    public class SteamArchievementsTester : MonoBehaviour
    {
        public Steamworks.Data.Achievement archievement = new Steamworks.Data.Achievement("ArchievementTest");
        

        public void IsArchievementUnlocked(string id)
        {
            Steamworks.SteamUserStats stats = new Steamworks.SteamUserStats();
            
            archievement.GetIconAsync();
            Debug.Log("The archievement: "+id+ " is " + archievement.State);
        }
        public void UnlockArchievement(string id)
        {
         
            archievement.Trigger();
            Debug.Log("The achievement: "+id+ " is archieved"+ archievement.State);
        }
        public void LockArchievement(string id)
        {
            archievement.Clear();
        }
    }
}
