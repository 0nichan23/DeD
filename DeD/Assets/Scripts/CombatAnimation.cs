using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimation : MonoBehaviour
{
    public static CombatAnimation Instance;
    public Animator croci;
    public Animator abiri;
    public ParticleSystem Fire;
    public ParticleSystem Poison;
    public ParticleSystem Ice;
    public ParticleSystem Lightning;
    public ParticleSystem Dark;
    public ParticleSystem Light;
    public ParticleSystem Heal;
    private void Awake()
    {
        Instance = this;
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
