using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMP_Text))]
public class ColorButton : MonoBehaviour {

    TMP_Text text;
    public Color colorStart;
    public Color colorEnd;

    public float speed;
    private void Start() {
        text = GetComponent<TMP_Text>();
    }
    private void Update() {
        text.color = Color.Lerp(colorStart, colorEnd, (Mathf.Sin(Time.time * speed) + 1) / 2);
    }
}
