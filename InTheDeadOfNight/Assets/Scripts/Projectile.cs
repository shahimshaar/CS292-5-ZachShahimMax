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
        Rotate();
    }

    void Rotate()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3 vectorToTarget = mouse - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2000000);
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