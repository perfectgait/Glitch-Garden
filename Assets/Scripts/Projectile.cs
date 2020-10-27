using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotation = 5000.0f;
    [SerializeField] float damage = 50.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);

        if (rotation != 0)
        {
            transform.Rotate(0.0f, 0.0f, rotation * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
