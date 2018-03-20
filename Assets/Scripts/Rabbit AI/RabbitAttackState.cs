using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAttackState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RabbitBehavior r = animator.GetComponent<RabbitBehavior>();
        if (r.xx > 0)
        {
            animator.SetFloat("Direction", 1);
            //r.transform.position += Vector3.right * Time.deltaTime * r.speed;
        }
        else if (r.xx < 0)
        {
            animator.SetFloat("Direction", 0);
            //r.transform.position += Vector3.left * Time.deltaTime * r.speed;
        }
    }

}
