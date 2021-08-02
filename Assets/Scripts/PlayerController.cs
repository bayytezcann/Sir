using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private FloatingJoystick floatingJoystick;
   [SerializeField] private float moveSpeed;

   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   private void Update()
   {
      if (GameController.Instance.GetGameStartState())
      {
         if (Mathf.Abs(floatingJoystick.Vertical) > floatingJoystick.DeadZone || Mathf.Abs(floatingJoystick.Horizontal) > floatingJoystick.DeadZone)
         {
            Rotate();
            Animation(true);
            Move();
         }
         else
         {
            Animation(false);
         }
      }
   }

   private void Rotate()
   {
      transform.rotation = Quaternion.Euler(0, Mathf.Atan2(-floatingJoystick.Vertical, floatingJoystick.Horizontal) * Mathf.Rad2Deg + 90f, 0);
   }
   
   private void Move()
   {
      transform.position += (Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal) * Time.deltaTime * moveSpeed;
   }

   private void Animation(bool isRun)
   {
      if (isRun)
      {
         if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("SetRun"))
         {
            AnimationRun();
         }
      }
      else
      {
         if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("SetIdle"))
         {
            AnimationIdle();
         }
      }
   }

   public void Completed()
   {
      AnimationIdle();
      enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Gem"))
      {
         GemController.Instance.RemoveGem(other.transform);
         GemController.Instance.CalculateGem();
         ScoreController.Instance.AddScore();
         Destroy(other.gameObject);
      }
   }

   //Animations
   private void AnimationIdle()
   {
      _animator.ResetTrigger("SetRun");
      _animator.SetTrigger("SetIdle");
   }
   
   private void AnimationRun()
   {
      _animator.ResetTrigger("SetIdle");
      _animator.SetTrigger("SetRun");
   }
}