using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Animation
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    public class FoxAnimationHelper : MonoBehaviour
    {

        #region Public Variables
        public System.Action OnArrivedToDestination;
        public System.Action OnAttackedTarget;
        #endregion

        #region Private Variables
        [SerializeField]
        private float m_timeToMove;

        [SerializeField]
        private float m_timeToTurn;

        [SerializeField]
        private GameObject m_deathEffect;

        [SerializeField]
        private GameObject m_runEffect;

        private Animator m_animator;
        private AudioSource m_source;
        private bool m_alreadyMoving = false;
        private bool m_alreadyAttacking = false;

        //Animator Toggle names
        private const string m_idle = "Idle2";
        private const string m_run = "Run";
        private const string m_attack = "Attack";
        #endregion

        #region Main Methods
        private void Start()
        {
            m_animator = GetComponent<Animator>();
            m_source = GetComponent<AudioSource>();

            ReturnToIdle();
        }

        public void MoveTo(Vector3 positionToMoveTo)
        {
            if (m_alreadyMoving || m_alreadyAttacking)
            {
                Debug.Log("Reaper already moving/attacking. Wait for reaper to finish " +
                          "moving/attacking before giving it a new destination to move to.");
                return;
            }

            StartCoroutine(Move(positionToMoveTo));
        }

        public void AttackPosition(Vector3 positionToAttack)
        {
            if (m_alreadyMoving || m_alreadyAttacking)
            {
                Debug.Log("Reaper already moving/attacking. Wait for reaper to finish " +
                          "moving/attacking before giving it a new destination to move to.");
                return;
            }

            StartCoroutine(Attack(positionToAttack));

        }

        public void SetToDead()
        {
            //ReturnToIdle();
            //m_animator.SetBool(m_die, true);

            GameObject effect = Instantiate(m_deathEffect);
            effect.transform.position = transform.position;
            effect.transform.position = new Vector3(effect.transform.position.x,
                                                    effect.transform.position.y + 0.5f,
                                                    effect.transform.position.z);

            StartCoroutine(Die());
        }

        #endregion

        #region Utility Methods

        void ReturnToIdle()
        {
            m_animator.SetTrigger(m_idle);
            //m_animator.SetBool(m_moveForward, false);
            //m_animator.SetBool(m_jump, false);
            //m_animator.SetBool(m_spinAttack, false);
        }

        void BeginMovingAnimation()
        {
            //ReturnToIdle();
            //m_animator.SetBool(m_moveForward, true);
            m_animator.SetTrigger(m_run);
            Instantiate(m_runEffect);
        }

        void AttackAnimation()
        {
            m_animator.SetTrigger(m_attack);
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(this.gameObject);
        }

        private IEnumerator Move(Vector3 pos)
        {
            m_alreadyMoving = true;

            Vector3 attractionVec = pos - transform.position;
            Quaternion desiredQuat = GetRotationQuaternion(pos);

            float m_startTime = 0f;
            Quaternion originalQuat = transform.rotation;

            while (m_startTime <= m_timeToTurn)
            {
                m_startTime += Time.deltaTime;

                Quaternion rot = originalQuat;
                rot = Quaternion.Slerp(rot, desiredQuat, m_startTime / m_timeToTurn);
                transform.rotation = rot;
                yield return null;

            }



            m_startTime = 0f;
            Vector3 originalPosition = transform.position;

            BeginMovingAnimation();

            while (Vector3.Distance(pos, transform.position) >= 0.05f)
            {
                m_startTime += Time.deltaTime;
                transform.position = Vector3.Lerp(originalPosition, pos, m_startTime / m_timeToMove);
                yield return null;
            }

            m_alreadyMoving = false;

            ReturnToIdle();
            FireDoneEvent();
        }

        private IEnumerator Attack(Vector3 pos)
        {
            m_alreadyAttacking = true;

            //Rotate towards target.
            Vector3 attractionVec = pos - transform.position;

            if (Vector3.Angle(attractionVec, transform.forward) > 30f)
            {
                Quaternion desiredQuat = GetRotationQuaternion(pos);
                float m_startTime = 0f;
                Quaternion originalQuat = transform.rotation;

                while (m_startTime <= m_timeToTurn)
                {
                    m_startTime += Time.deltaTime;

                    Quaternion rot = originalQuat;
                    rot = Quaternion.Slerp(rot, desiredQuat, m_startTime / m_timeToTurn);
                    transform.rotation = rot;
                    yield return null;

                }
            }


            AttackAnimation();
            StartCoroutine(PlayAttackAudio());

            yield return new WaitForSeconds(1f);

            m_alreadyAttacking = false;

            ReturnToIdle();
            FireDoneAttackingEvent();
        }

        private IEnumerator PlayAttackAudio()
        {
            /*
            yield return new WaitForSeconds(0.6f);
            int index = UnityEngine.Random.Range(0, m_wooshClips.Length);
            m_source.clip = m_wooshClips[index];
            m_source.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            m_source.Play();
            */
            yield return null;
        }

        private Quaternion GetRotationQuaternion(Vector3 desirePosition)
        {
            Vector3 attractionVec = desirePosition - transform.position;

            float angle = Vector3.Angle(transform.forward, attractionVec);
            float rightAngle = Vector3.Angle(transform.right, attractionVec);
            float leftAngle = Vector3.Angle(-transform.right, attractionVec);

            if (leftAngle < rightAngle)
            {
                angle *= -1;
            }

            Quaternion desiredQuat = transform.rotation * Quaternion.Euler(new Vector3(0, angle, 0));
            return desiredQuat;
        }

        private void FireDoneEvent()
        {
            if (OnArrivedToDestination == null)
                return;

            OnArrivedToDestination();
        }

        private void FireDoneAttackingEvent()
        {
            if (OnAttackedTarget == null)
                return;

            OnAttackedTarget();
        }

        #endregion
    }
}
