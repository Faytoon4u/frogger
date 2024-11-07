using UnityEngine;
using UnityEngine.UI; // Required for accessing UI elements
using UnityEngine.SceneManagement; // Required for scene management

public class FinishLine : MonoBehaviour
{
    public Text winText; // Reference to the UI Text component
    public float reloadDelay = 2f; // Delay before reloading the scene

    private void Start()
    {
        // Ensure the winText is hidden at the start
        if (winText != null)
            winText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        Debug.Log("Level Completed!");

        // Show the win text
        if (winText != null)
            winText.enabled = true;

        // Invoke the ReloadScene function after a delay
        Invoke("ReloadScene", reloadDelay);
    }

    void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
