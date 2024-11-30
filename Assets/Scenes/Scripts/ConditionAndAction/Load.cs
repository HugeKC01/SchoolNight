using UnityEngine;
using UnityEngine.SceneManagement;

public class AnomalySceneManager : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to the anomaly object in the scene.")]
    public AnomalyObject anomalyObject;

    [Header("Scene Management")]
    [Tooltip("Name of the next scene to load when the player enters the trigger.")]
    public string nextSceneName;

    private void HandleSceneTransition()
    {
        if (anomalyObject == null)
        {
            Debug.LogError("AnomalyObject reference is missing! Please assign it in the Inspector.");
            return;
        }

        if (anomalyObject.CheckAnomaly())
        {
            Debug.Log("Anomaly detected. Loading the previous scene...");
            LoadPreviousScene();
        }
        else
        {
            Debug.Log("No anomaly detected. Loading the next scene...");
            LoadNextScene();
        }
    }

    private void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            Debug.LogWarning("Already at the first scene. Cannot go back further.");
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("Already at the last scene. Cannot go forward.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                Debug.Log($"Player entered the trigger. Loading scene: {nextSceneName}");
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Next scene name is not set! Please assign a scene name in the Inspector.");
            }
        }
    }
}

