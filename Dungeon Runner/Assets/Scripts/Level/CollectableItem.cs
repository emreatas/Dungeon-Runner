using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    private MeshRenderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Collect()
    {

        particleSystem.Play();
        _renderer.enabled = false;
        //gameObject.SetActive(false);

    }



}
