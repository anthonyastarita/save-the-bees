using System;
using System.Collections;
using UnityEngine;

public class BranchFall : MonoBehaviour
{
    private Rigidbody2D rb;

    public event Action OnBranchPassedQueen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float speed, float queenY)
    {
        rb.velocity = new Vector2(0.0f, -speed);
        StartCoroutine(FallUpdate(queenY));


    }

    private IEnumerator FallUpdate(float queenY)
    {
        yield return new WaitUntil(() => transform.position.y < queenY);
        OnBranchPassedQueen?.Invoke();
    }

}
