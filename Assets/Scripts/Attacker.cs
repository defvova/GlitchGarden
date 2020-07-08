using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float walkSpeed = 0f;

    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }
}