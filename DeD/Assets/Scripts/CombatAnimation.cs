using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimation : MonoBehaviour
{
    public static CombatAnimation Instance;
    public Animator croci;
    public Animator abiri;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CrocTailSmah()
    {
        croci.ResetTrigger("TailSmash");
        croci.SetTrigger("TailSmash");
    }

    public void CrocBite()
    {
        croci.ResetTrigger("Bite");
        croci.SetTrigger("Bite");
    }

    public void KnightAttack()
    {
        abiri.ResetTrigger("Attack");
        abiri.SetTrigger("Attack");
    }
}
