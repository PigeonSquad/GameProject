using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Control
{


public class AIController : MonoBehaviour
{
    [SerializeField] float chaseDistance= 5f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(DistanceToPlayer() < chaseDistance)
        {
            print(gameObject.name + "Should chase");
        }
    }
    private float DistanceToPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
}