using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleKnife : BaseSkill
{


    IEnumerator WaitForFirstKnife(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(gameObject);

    }
    public override void Cast(GameObject gameObject)
    {
        base.Cast(gameObject);
        StartCoroutine(WaitForFirstKnife(gameObject));

    }
}
