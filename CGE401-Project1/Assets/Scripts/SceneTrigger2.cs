using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Mimi Davis
* Project1
* Makes player walk into trigger zone to get to the next scene
*/
    public class SceneTrigger2 : MonoBehaviour
    {
        public string nextSceneName; // Assign the name of the next scene in the Inspector

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the entering object is the player (or whatever you want to trigger the scene change)
            if (other.CompareTag("Player")) 
            {
                SceneManager.LoadScene(nextSceneName); 
            }
        }
    }