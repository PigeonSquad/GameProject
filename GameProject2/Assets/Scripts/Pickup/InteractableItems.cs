using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        //this method is ment to be overwritten
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < radius && !hasInteracted)
        {
            Interact();
            hasInteracted = true;
        }
    }
}
