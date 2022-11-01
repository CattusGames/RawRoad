using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObstacle : MonoBehaviour
{
    [SerializeField][Range(0, 10)]private int timeBonus;
    [Range(0,10f)][SerializeField] private float _speed;
    [Range(0, 10f)][SerializeField] private float _pause;
    private Rigidbody rb;
    private GameProgressManager GPMngr;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GPMngr = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<GameProgressManager>();

    }
    public void Jump()
    {
        if (_pause <= 0)
        {
            anim.SetTrigger("Jump");
            rb.AddForce((transform.forward+transform.up) * _speed, ForceMode.Impulse);

        }
        else
        {

        }

    }

    private IEnumerator Pause(float pause)
    {
        yield return new WaitForSeconds(pause);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GPMngr.SolidObstacleEvent?.Invoke(timeBonus, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Jump();
    }
}
