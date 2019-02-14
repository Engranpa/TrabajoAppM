using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    private void OnTriggerEnter(Collider other){
        other.GetComponent<Vida>().currentHealth += 10;
        Destroy(gameObject);
    }
}
