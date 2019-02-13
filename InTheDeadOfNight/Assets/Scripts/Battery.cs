using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private GameObject playerObject;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerObject = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Projectile")
        {
            playerObject.GetComponent<Player>().Battery();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
