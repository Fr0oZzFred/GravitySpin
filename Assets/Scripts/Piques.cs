using UnityEngine;

public class Piques : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerController>()) {
            GameManager.Instance.ChangeGameState("GameOver");
        }
    }
}
