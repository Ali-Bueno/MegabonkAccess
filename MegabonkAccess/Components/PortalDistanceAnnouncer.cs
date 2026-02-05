using System;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Anuncia la distancia al portal del siguiente nivel al presionar P.
    /// </summary>
    public class PortalDistanceAnnouncer : MonoBehaviour
    {
        private Transform playerTransform = null;
        private float nextPlayerSearchTime = 0f;

        // Cooldown para evitar spam
        private float lastAnnounceTime = 0f;
        private float announceCooldown = 0.5f;

        static PortalDistanceAnnouncer()
        {
            ClassInjector.RegisterTypeInIl2Cpp<PortalDistanceAnnouncer>();
        }

        void Update()
        {
            try
            {
                // Buscar jugador periódicamente
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                // Detectar tecla P
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (Time.time - lastAnnounceTime >= announceCooldown)
                    {
                        AnnouncePortalDistance();
                        lastAnnounceTime = Time.time;
                    }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[PortalDistance] Update error: {e.Message}");
            }
        }

        private void FindPlayer()
        {
            try
            {
                string[] playerNames = { "Player", "Character", "PlayerCharacter", "Hero" };
                foreach (var name in playerNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        if (obj.name == "Camera" || obj.transform.parent?.name?.Contains("Camera") == true)
                            continue;

                        playerTransform = obj.transform;
                        break;
                    }
                }

                // Fallback a cámara
                if (playerTransform == null)
                {
                    var cam = Camera.main;
                    if (cam != null)
                        playerTransform = cam.transform;
                }
            }
            catch { }
        }

        private void AnnouncePortalDistance()
        {
            if (playerTransform == null)
            {
                TolkUtil.Speak("Jugador no encontrado");
                return;
            }

            Vector3 playerPos = playerTransform.position;
            GameObject closestPortal = null;
            float closestDistance = float.MaxValue;

            // Buscar portales por nombre
            string[] portalNames = {
                "Portal", "Portal(Clone)", "Portal (Clone)",
                "BossSpawner", "BossSpawner(Clone)", "BossSpawner (Clone)",
                "NextLevelPortal", "ExitPortal", "LevelPortal"
            };

            foreach (var portalName in portalNames)
            {
                try
                {
                    var portal = GameObject.Find(portalName);
                    if (portal != null && portal.activeInHierarchy)
                    {
                        float dist = Vector3.Distance(playerPos, portal.transform.position);
                        if (dist < closestDistance)
                        {
                            closestDistance = dist;
                            closestPortal = portal;
                        }
                    }
                }
                catch { }
            }

            // También buscar en contenedores comunes
            string[] containers = { "Interactables", "Objects", "World", "Level", "Spawned" };
            foreach (var containerName in containers)
            {
                try
                {
                    var container = GameObject.Find(containerName);
                    if (container != null)
                    {
                        SearchPortalInContainer(container.transform, playerPos, ref closestPortal, ref closestDistance);
                    }
                }
                catch { }
            }

            // Anunciar resultado
            if (closestPortal != null)
            {
                // Redondear distancia
                int distanceRounded = Mathf.RoundToInt(closestDistance);
                string message = $"Portal a {distanceRounded} unidades";
                TolkUtil.Speak(message);
                Plugin.Log.LogInfo($"[PortalDistance] {message} ({closestPortal.name})");
            }
            else
            {
                TolkUtil.Speak("No hay portal en este nivel");
                Plugin.Log.LogInfo("[PortalDistance] No portal found");
            }
        }

        private void SearchPortalInContainer(Transform container, Vector3 playerPos, ref GameObject closestPortal, ref float closestDistance)
        {
            if (container == null) return;

            try
            {
                for (int i = 0; i < container.childCount; i++)
                {
                    var child = container.GetChild(i);
                    if (child == null || !child.gameObject.activeInHierarchy) continue;

                    string lowerName = child.name.ToLower();

                    // Buscar portales y BossSpawner
                    if (lowerName.Contains("portal") || lowerName.Contains("bossspawner"))
                    {
                        float dist = Vector3.Distance(playerPos, child.position);
                        if (dist < closestDistance)
                        {
                            closestDistance = dist;
                            closestPortal = child.gameObject;
                        }
                    }

                    // Recursión limitada
                    if (child.childCount > 0)
                    {
                        SearchPortalInContainer(child, playerPos, ref closestPortal, ref closestDistance);
                    }
                }
            }
            catch { }
        }
    }
}
