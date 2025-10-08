using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [Header("GameObjects with scripts to disable (e.g. Player, AI)")]
    public GameObject[] objectsWithScriptsToDisable;

    [Header("GameObjects to deactivate (HUD, gameplay elements)")]
    public GameObject[] objectsToDisable;

    public void PauseGame()
    {
        foreach (var go in objectsWithScriptsToDisable)
        {
            if (go != null)
            {
                MonoBehaviour[] scripts = go.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    script.enabled = false;
                }
            }
        }

        foreach (var obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        foreach (var go in objectsWithScriptsToDisable)
        {
            if (go != null)
            {
                MonoBehaviour[] scripts = go.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    script.enabled = true;
                }
            }
        }

        foreach (var obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
