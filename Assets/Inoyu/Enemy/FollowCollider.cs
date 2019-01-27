using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCollider : MonoBehaviour
{
    protected EnemySerch enemyserch;
    // Start is called before the first frame update
    void Start()
    {
        enemyserch = transform.GetComponentInParent<EnemySerch>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            enemyserch.OnEnterFollowTarget();
        }
    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            enemyserch.OnExitFollowTarget(c.transform);
        }
    }
}
