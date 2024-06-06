using UnityEngine;

public class Saw : MonoBehaviour
{
    public GameObject pathA;
    public GameObject pathB;
    public float speed; // Speed at which the saw moves
    public float tolerance; // How close the saw needs to be to switch targets

    private Vector3 currentTarget;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentTarget = pathA.transform.position; // Set initial target
        SawAnim(); // Start the saw animation
    }

    // Update is called once per frame
    void Update()
    {
        SawMove();
    }

    void SawMove()
    {
        // Move towards the current target
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Check if the saw has reached the target
        if (Vector3.Distance(transform.position, currentTarget) < tolerance)
        {
            // Switch to the other target
            if (currentTarget == pathA.transform.position)
            {
                currentTarget = pathB.transform.position;
            }
            else
            {
                currentTarget = pathA.transform.position;
            }
        }
    }

    void SawAnim()
    {
        anim.enabled = true;
    }
}
