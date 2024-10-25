using System.Collections.Generic;
using UnityEngine;

public static class ColliderTwiddler
{
    static List<Collider> colliders = new();

    /**
     * This is a hack to force the colliders to trigger OnTriggerEnter/etc.
     * Call this after instantiating an object or adding a rigidbody to it.
     */
    public static void Twiddle(GameObject gameObject)
    {
        colliders.Clear();
        gameObject.GetComponentsInChildren(colliders);
        foreach (Collider collider in colliders)
        {
            bool val = collider.enabled;
            if (val)
            {
                collider.enabled = false;
                collider.enabled = true;
            }
        }
    }
}
