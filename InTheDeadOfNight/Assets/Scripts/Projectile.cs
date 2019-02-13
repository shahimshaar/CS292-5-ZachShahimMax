using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        BoundryCond();
    }

    void BoundryCond()
    {
        if (transform.position.y > 2.0f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y < -2.0f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x > 3.5f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x < -3.5f)
        {
            Destroy(this.gameObject);
        }
    }
}