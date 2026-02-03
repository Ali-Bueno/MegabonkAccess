using HarmonyLib;
using Assets.Scripts.Actors.Enemies;
using System.Collections.Generic;

namespace MegabonkAccess.Patches
{
    /// <summary>
    /// Patch para registrar enemigos cuando se inicializan.
    /// Permite al EnemyAnnouncementSystem acceder a todos los enemigos activos.
    /// </summary>
    public static class EnemyTracker
    {
        private static HashSet<Enemy> activeEnemies = new HashSet<Enemy>();
        private static object lockObj = new object();

        public static IEnumerable<Enemy> GetActiveEnemies()
        {
            lock (lockObj)
            {
                // Return a copy to avoid modification during enumeration
                return new List<Enemy>(activeEnemies);
            }
        }

        public static int Count
        {
            get
            {
                lock (lockObj)
                {
                    return activeEnemies.Count;
                }
            }
        }

        public static void RegisterEnemy(Enemy enemy)
        {
            if (enemy == null) return;
            lock (lockObj)
            {
                if (activeEnemies.Add(enemy))
                {
                    Plugin.Log.LogDebug($"[EnemyTracker] Registered enemy: {enemy.gameObject?.name}");
                }
            }
        }

        public static void UnregisterEnemy(Enemy enemy)
        {
            if (enemy == null) return;
            lock (lockObj)
            {
                activeEnemies.Remove(enemy);
            }
        }

        public static void Clear()
        {
            lock (lockObj)
            {
                activeEnemies.Clear();
            }
        }

        public static void CleanupDeadEnemies()
        {
            lock (lockObj)
            {
                activeEnemies.RemoveWhere(e => {
                    try
                    {
                        return e == null || e.gameObject == null || !e.gameObject.activeInHierarchy;
                    }
                    catch
                    {
                        return true;
                    }
                });
            }
        }
    }

    /// <summary>
    /// Patch Enemy.InitEnemy to register enemies when they spawn
    /// </summary>
    [HarmonyPatch(typeof(Enemy), nameof(Enemy.InitEnemy))]
    public static class EnemyInitPatch
    {
        public static void Postfix(Enemy __instance)
        {
            try
            {
                EnemyTracker.RegisterEnemy(__instance);
            }
            catch { }
        }
    }

    /// <summary>
    /// Patch Enemy.Kill to unregister enemies when they die
    /// </summary>
    [HarmonyPatch(typeof(Enemy), nameof(Enemy.Kill))]
    public static class EnemyKillPatch
    {
        public static void Postfix(Enemy __instance)
        {
            try
            {
                EnemyTracker.UnregisterEnemy(__instance);
            }
            catch { }
        }
    }
}
