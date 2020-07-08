using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 2f)] [SerializeField] private float walkSpeed = 1f;

    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}