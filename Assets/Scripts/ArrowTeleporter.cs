using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrowTeleporter : MonoBehaviour
{
    SpriteRenderer sr;
    public Vector3 scaleStart;
    public Vector3 scaleEnd;
    public Vector2 posStart;
    public Vector2 posEnd;
    public Color colorStart;
    public Color colorEnd;
    public float speed = 1;
    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        sr.gameObject.transform.localPosition = Vector2.Lerp(posStart, posEnd, (Mathf.Sin(Time.time * speed) + 1) / 2);
        sr.gameObject.transform.localScale = Vector3.Lerp(scaleStart, scaleEnd, (Mathf.Sin(Time.time * speed) + 1) / 2);
        sr.color = Color.Lerp(colorStart, colorEnd, (Mathf.Sin(Time.time * speed) + 1) / 2);
    }
}
