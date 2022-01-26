using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public Image image;
    public TMP_Text text;
    public float speed;
    public bool arrow;
    public Image arrowLeft;
    public Image arrowRight;
    private void Start() {

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        if (arrow) {
            arrowLeft.color = new Color(arrowLeft.color.r, arrowLeft.color.g, arrowLeft.color.b, 0);
            arrowRight.color = new Color(arrowRight.color.r, arrowRight.color.g, arrowRight.color.b, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<PlayerController>() != null) {
            StartCoroutine(DisplayDialogueBox());
        }
    }

    IEnumerator DisplayDialogueBox() {
        image.gameObject.SetActive(true);
        while(image.color.a != 255) {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.01f);
            if (arrow) {
                arrowLeft.color = new Color(arrowLeft.color.r, arrowLeft.color.g, arrowLeft.color.b, arrowLeft.color.a + 0.01f);
                arrowRight.color = new Color(arrowRight.color.r, arrowRight.color.g, arrowRight.color.b, arrowRight.color.a + 0.01f);
            }
            yield return new WaitForSeconds(speed);
        }
        this.gameObject.SetActive(false);
    }
}
