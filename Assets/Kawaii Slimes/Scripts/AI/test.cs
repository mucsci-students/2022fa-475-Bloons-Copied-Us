
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{

    public enum SlimeAnimationState { Idle,Walk,Jump,Attack,Damage}

    public Face faces;
    public GameObject SmileBody;
    public SlimeAnimationState currentState; 
   
    public Animator animator;
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public int damType;

    private int m_CurrentWaypointIndex;

    private bool move;
    private Material faceMaterial;
    private Vector3 originPos;

    public enum WalkType { Patroll ,ToOrigin }
    private WalkType walkType;

    void Start()
    {
        originPos = transform.position;
        faceMaterial = SmileBody.GetComponent<Renderer>().materials[1];
        walkType = WalkType.ToOrigin;
        currentState = SlimeAnimationState.Walk;
    }
       void SetFace(Texture tex)
    {
        faceMaterial.SetTexture("_MainTex", tex);
    }

    void Update()
    {
        

        switch (currentState)
        {

            case SlimeAnimationState.Walk:

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) return;

                agent.isStopped = false;
                agent.updateRotation = true;

                if (walkType == WalkType.ToOrigin)
                {
                    agent.SetDestination(originPos);
                    // Debug.Log("WalkToOrg");
                    SetFace(faces.WalkFace);
                    // agent reaches the destination
                    if (agent.remainingDistance < agent.stoppingDistance)
                    {
                        walkType = WalkType.Patroll;

                        //facing to camera
                        transform.rotation = Quaternion.identity;

                        currentState = SlimeAnimationState.Idle;
                    }
                       
                }

                // set Speed parameter synchronized with agent root motion moverment
                animator.SetFloat("Speed", agent.velocity.magnitude);
            
                break;
       
        }

    }

    void OnAnimatorMove()
    {
        // apply root motion to AI
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
        agent.nextPosition = transform.position;
    }
    }
