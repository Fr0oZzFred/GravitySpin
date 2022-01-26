using UnityEngine;
using System.Collections;
public class Piques : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null) {
            p.Stop();
            p.enabled = false;
            p.GetComponent<SpriteRenderer>().color = Color.red;
            p.GetComponent<Animator>().SetFloat("Speed", 0);
            StartCoroutine(End());
        }
    }
    IEnumerator End() {
        SoundManager.Instance.StopAllSounds();
        SoundManager.Instance.Play("LooseTheme");
        yield return new WaitForSeconds(1);
        GameManager.Instance.ChangeGameState("GameOver");
    }
}
