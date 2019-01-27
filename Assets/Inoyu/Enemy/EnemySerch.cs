using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySerch : MonoBehaviour
{

    public float move_speed = 3.0f;

    protected Rigidbody rb;
    protected Transform followTarget;
    protected MoveMode CurrentMoveMode;

    public enum MoveMode
    {
        Idle = 1,
        Follow = 2,
        Wait = 3
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        CurrentMoveMode = MoveMode.Idle;
        
    }

    // Update is called once per frame
    void Update()
    {
        DoAutoMovement();
    }

    protected void DoAutoMovement()
    {
        switch (CurrentMoveMode)
        {
            case MoveMode.Wait:
                break;
            case MoveMode.Follow:
                if (followTarget != null)
                {
                    Quaternion move_rotation = Quaternion.LookRotation(followTarget.transform.position - transform.position, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, move_rotation, 0.1f);
                    rb.velocity = transform.forward * move_speed;
                }

                break;
        }
    }

    public void OnEnterFollowTarget()
    {
        followTarget = null;

        if (CurrentMoveMode == MoveMode.Follow)
        {
            CurrentMoveMode = MoveMode.Idle;
        }
    }

    public void OnExitFollowTarget(Transform target)
    {
        followTarget = target;

        if (CurrentMoveMode == MoveMode.Idle)
        {
            CurrentMoveMode = MoveMode.Follow;
        }
    }
}
