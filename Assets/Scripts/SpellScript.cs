using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpellScript : NetworkBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<HealthbarController>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}