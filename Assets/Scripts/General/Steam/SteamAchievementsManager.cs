using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SteamAchievementsManager
{
    // Start is called before the first frame update
    public static Steamworks.Data.Achievement archDeath = new Steamworks.Data.Achievement("ARCH_3");
    public static Steamworks.Data.Achievement archWin = new Steamworks.Data.Achievement("ARCH_4");
    public static Steamworks.Data.Achievement archWalk = new Steamworks.Data.Achievement("ARCH_2");
    public static Steamworks.Data.Achievement archRotate = new Steamworks.Data.Achievement("ARCH_1");

    public static void ResetAllAchievements()
    {
        archDeath.Clear();
        archWin.Clear();
        archWalk.Clear();
        archRotate.Clear();
    }

    public static void UnlockAchievement(Steamworks.Data.Achievement achievement)
    {
        achievement.Trigger();
    }
}
