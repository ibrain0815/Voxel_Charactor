using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GateTrigger : MonoBehaviour
{
    [SerializeField] private string targetScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene);
        }

    }
}
