using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDisabled : MonoBehaviour
{
    public bool SelfDestuctionEnabled { get; set; } = false;

    private void OnDisable()
    {
        if (SelfDestuctionEnabled)
        {
            Destroy(gameObject);
        }
    }
}
