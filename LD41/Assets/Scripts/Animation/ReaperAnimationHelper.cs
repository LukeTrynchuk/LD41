using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LD.Animation
{
    [RequireComponent(typeof(Animator))]
    public class ReaperAnimationHelper : MonoBehaviour
    {
        #region Public Variables
        public System.Action OnArrivedToDestination;
        #endregion

        #region Private Variables
        [SerializeField]
		private float m_timeToMove;

        [SerializeField]
        private float m_timeToTurn;

        private Animator m_animator;
        private bool m_alreadyMoving = false;

        //Animator bool names
        private const string m_moveForward = "Move Forward";
        private const string m_jump = "Jump";
        private const string m_spinAttack = "Spin Attack";

        //Animator trigger names
        private const string m_slash1 = "Slack Attack 01";
        private const string m_slash2 = "Slack Attack 02";
        private const string m_die = "Die";
		#endregion

		#region Main Methods
		private void Start()
		{
            m_animator = GetComponent<Animator>();
		}

        public void MoveTo(Vector3 positionToMoveTo)
        {
            if (m_alreadyMoving)
            {
                Debug.Log("Reaper already moving. Wait for reaper to finish " +
                          "moving before giving it a new destination to move to.");            
				return;
            }

            StartCoroutine(Move(positionToMoveTo));
        }

        public void SetToDead()
        {
            ReturnToIdle();
            m_animator.SetBool(m_die, true);
        }

		#endregion

		#region Utility Methods
		void ReturnToIdle()
        {
            m_animator.SetBool(m_moveForward, false);
            m_animator.SetBool(m_jump, false);
            m_animator.SetBool(m_spinAttack, false);
        }

        void BeginMovingAnimation()
        {
            ReturnToIdle();
            m_animator.SetBool(m_moveForward, true);
        }

        private IEnumerator Move(Vector3 pos)
		{
            m_alreadyMoving = true;

            Vector3 attractionVec = transform.position - pos;
            Quaternion desiredQuat = GetRotationQuaternion(pos);

            float m_startTime = 0f;
            Quaternion originalQuat = transform.rotation;

            while(m_startTime <= m_timeToTurn)
            {
				m_startTime += Time.deltaTime;
    
                Quaternion rot = originalQuat;
                rot = Quaternion.Slerp(rot, desiredQuat, m_startTime / m_timeToTurn);
                transform.rotation = rot;
                yield return null;

            }



            m_startTime = 0f;
            Vector3 originalPosition = transform.position;

            while(Vector3.Distance(pos, transform.position) >= 0.05f)
            {
				m_startTime += Time.deltaTime;
                transform.position = Vector3.Lerp(originalPosition, pos, m_startTime / m_timeToMove);
                yield return null;
            }



            FireDoneEvent();

            m_alreadyMoving = false;
		}

        private Quaternion GetRotationQuaternion(Vector3 desirePosition)
        {
            Vector3 attractionVec = desirePosition - transform.position;

            float angle = Vector3.Angle(transform.forward, attractionVec);
            float rightAngle = Vector3.Angle(transform.right, attractionVec);

            if (angle < rightAngle)
            {
                angle *= -1;
            }

            Quaternion desiredQuat = Quaternion.Euler(new Vector3(0, angle, 0));
            return desiredQuat;
        }

		private void FireDoneEvent()
        {
            if (OnArrivedToDestination == null)
                return;

            OnArrivedToDestination();
        }

        #endregion

	}
}
