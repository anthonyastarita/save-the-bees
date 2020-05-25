using System.Collections;
using UnityEngine;

public class FollowQueen : MonoBehaviour
{
    private Rigidbody2D rb;

    private const float FOLLOW_RADIUS = 3.0f;
    private const float SPEED = 4.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    public void Init(Transform queen)
    {
        StartCoroutine(FollowUpdate(queen));
    }

    private IEnumerator FollowUpdate(Transform queen)
    {
		var followDistance = (Vector3)Random.insideUnitCircle * FOLLOW_RADIUS;
		while (gameObject.activeSelf)
		{
			var targetPosition = followDistance + queen.position;

			//applies a spring movement behaviour, gets faster the further the bee is away from the queen
			rb.velocity = (targetPosition - transform.position + (Vector3)Random.insideUnitCircle * 2.0f) * SPEED;

			yield return new WaitForFixedUpdate();
		}
	}
}
