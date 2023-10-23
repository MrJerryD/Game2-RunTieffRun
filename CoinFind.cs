using UnityEngine;
using UnityEngine.UI;

public class CoinFind : MonoBehaviour
{
    public Text text;
    private float coins = 0;

    public AudioSource coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            UpdateCountText();
            PlayCoinSound();
            Destroy(collision.gameObject);
        }
    }

    void UpdateCountText()
    {
        text.text = "Score: " + coins;
    }

    void PlayCoinSound()
    {
        if (coinSound != null)
        {
            coinSound.Play();
        }
    }
}
