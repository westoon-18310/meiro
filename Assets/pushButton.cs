using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushButton : MonoBehaviour
{
    public int isPush = 0;
    private bool hasSunken = false;

    public float sinkDepth = 0.5f;
    public float sinkSpeed = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Renderer buttonRenderer;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition - new Vector3(0, sinkDepth, 0);
        buttonRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!hasSunken && other.gameObject.CompareTag("Player"))
        {
            isPush += 1;
            StartCoroutine(SinkButton());
            buttonRenderer.material.color = new Color(139f / 255f, 0.02f, 0f); // 暗い赤
            hasSunken = true;
        }
    }

    IEnumerator SinkButton()
    {
        float t = 0f;
        Vector3 startPos = transform.position;

        while (t < 1f)
        {
            t += Time.deltaTime * sinkSpeed;
            transform.position = Vector3.Lerp(startPos, targetPosition, t);
            yield return null;
        }
    }
}
