using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private int runID;
    private int idleID;
    private int punchID;
    private int hitID;
    private int deathID;

    private void Awake()
    {
        idleID = Animator.StringToHash("Idle");
        runID = Animator.StringToHash("Run");
        punchID = Animator.StringToHash("Punch");
        hitID = Animator.StringToHash("Hit");
        deathID = Animator.StringToHash("Death");
    }

    public void SetPunchTrigger()
    {
        SetTrigger(punchID);
    }
    public void SetHitTrigger()
    {
        SetTrigger(hitID);
    }

    public void SetDeathTrigger()
    {
        SetTrigger(deathID);
    }

    public void SetIdletrigger()
    {
        SetTrigger(idleID);
    }

    public void SetRunTrigger()
    {
        SetTrigger(runID);
    }

    public void SetTrigger(int id) => animator.SetTrigger(id);
}
