using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_S : MonoBehaviour {

    void OnCollisionEnter(Collision collision){
        var hit = collision.gameObject;
        var health = hit.GetComponent<Vida>();
        if (health != null){
            health.TakeDamage(10);
        }

        Destroy(gameObject);

    }
}
