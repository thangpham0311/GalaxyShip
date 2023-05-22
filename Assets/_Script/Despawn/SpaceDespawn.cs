using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDespawn : MonoBehaviour
{
    protected float distance = 0;
    private void FixedUpdate()
    {
        this.UpdateSpace();
    }
    protected virtual void UpdateSpace()
    {
        this.distance = Vector2.Distance(PlayerCtrl.Instance.transform.position, transform.position);
        if (this.distance > 70) this.Despawn();
    }

    protected virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
