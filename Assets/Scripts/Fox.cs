using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        // If it's a gravestone, jump over it
        if (otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");

            return;
        }

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
