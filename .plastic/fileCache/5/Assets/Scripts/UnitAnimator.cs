using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Awake()
    {
        if (TryGetComponent<MoveAction>(out MoveAction moveAction))
        {
            moveAction.OnStartMoving += MoveAction_OnStartMoving;
            moveAction.OnStopMoving += MoveAction_OnStopMoving;
        }
        if (TryGetComponent<ShootAction>(out ShootAction shootAction))
        {
            shootAction.OnShoot += ShootAction_OnShoot;
        }
    }

    private void MoveAction_OnStartMoving(object sender, EventArgs e)
    {
        anim.SetBool("isWalking", true);
    }
    private void MoveAction_OnStopMoving(object sender, EventArgs e)
    {
        anim.SetBool("isWalking", false);
    }
    private void ShootAction_OnShoot(object sender, EventArgs e)
    {
        anim.SetTrigger("Shoot");
    }
}
