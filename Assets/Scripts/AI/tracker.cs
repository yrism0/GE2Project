using UnityEngine;

using UnityEngine.AI;// uses build in AI features in unity

public class tracker : MonoBehaviour
{
    // list of varables 
    NavMeshAgent Z;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");// targets player on spawn
        Z = GetComponent<NavMeshAgent>();// gets navmesh to see where AI can move too
    }

    // Update is called once per frame
    void Update()
    {
        Z.SetDestination(target.transform.position);// updates the targets position 
    }
   
}
