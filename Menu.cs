using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    //public void ExitMenu()
    //{
    //    //Application.Quit();
    //    SceneManager.LoadScene("Menu");
    //}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Обработка нажатия пальцем
        //Debug.Log("Палец нажат!");
    }
}
