using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;




    public void Collect()
    {

        particleSystem.Play();
        gameObject.SetActive(false);

    }



}
