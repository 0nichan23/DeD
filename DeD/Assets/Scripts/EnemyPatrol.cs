using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Triggered", true);
        }
    }
}
