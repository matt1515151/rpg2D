using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // and thy punishment..
            // is DEATH
            StartCoroutine(collision.GetComponent<PlayerSpawn>().Die());
        }
    }
}
