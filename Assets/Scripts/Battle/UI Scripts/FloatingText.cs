using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    float timeAlive = 0;
    [SerializeField] float speed;
    [SerializeField] float xSpeedRange;
    [SerializeField] float lifetime;
    TMP_Text text;
    Color textColor;
    float xSpeed;
    private void Start()
    {
        text = GetComponent<TMP_Text>();
        textColor = text.color;
        xSpeed = Random.Range(-xSpeedRange, xSpeedRange);
        speed *= Random.Range(0.8f, 1.2f);
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        transform.position += new Vector3(Time.deltaTime * xSpeed, Time.deltaTime * speed, 0);
        if (timeAlive > lifetime/2f)
        {
            textColor.a = (lifetime / 2f - (timeAlive - lifetime / 2f)) / (lifetime / 2f);
            text.color = textColor;
        }
        if (timeAlive > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
