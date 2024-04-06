using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 50f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        public Collider2D movementBounds;
        public Vector2 minCameraPosition;
        public Vector2 maxCameraPosition;

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;

        public InputAction moveAction;

        protected Joystick joystick;

        void LateUpdate()
        {
            if (alive)
            {
                Vector3 targetPosition = transform.position;
                targetPosition.z = Camera.main.transform.position.z;

                float clampedX = Mathf.Clamp(targetPosition.x, minCameraPosition.x, maxCameraPosition.x);
                float clampedY = Mathf.Clamp(targetPosition.y, minCameraPosition.y, maxCameraPosition.y);

                Camera.main.transform.position = new Vector3(clampedX, clampedY, targetPosition.z);
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            moveAction.Enable();
            joystick = FindObjectOfType<Joystick>(joystick);
        }

        public void OnEnable()
        {
            moveAction.Enable();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                //Hurt();
                //Die();
                //Attack();
                Jump();
                //KickBoard();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

    void Run()
    {
        if (!isKickboard)
        {
            anim.SetBool("isRun", false);
            Vector2 move = new Vector2(joystick.Horizontal * 2, 0);

            if (move != Vector2.zero)
            {
                anim.SetBool("isRun", true);
            }

            if (move.x < 0)
            {
                direction = -1;
            }
            else if (move.x > 0)
            {
                direction = 1;
            }

            transform.localScale = new Vector3(direction, 1, 1);
            Vector2 clampedPosition = movementBounds.ClosestPoint(rb.position + move * movePower * Time.deltaTime);
            rb.MovePosition(clampedPosition);
        }
    }

        void Jump()
        {
            return;
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }

}