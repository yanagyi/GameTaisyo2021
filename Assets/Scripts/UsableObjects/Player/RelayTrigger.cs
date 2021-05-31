using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class RelayTrigger : MonoBehaviour
{
    [SerializeField] GameObject relayTo;
    private PlayerSE playerSE;

    private void Awake()
    {
        playerSE = relayTo.GetComponent<PlayerSE>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerSE.RelayedTrigger(other);
    }
}