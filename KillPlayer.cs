using UnityEngine;
using UnityEngine.SceneManagement; // Эта библиотека необходима для управления сценами


public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
            //Application.Quit();
            Debug.Log("Game is Over");
        }
    }
}
