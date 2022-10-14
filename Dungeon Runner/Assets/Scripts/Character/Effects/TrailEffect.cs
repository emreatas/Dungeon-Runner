using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public float activeTime = 2f;

    public float meshRefreshRate=0.1f;

    public float meshDestroyDelay=0.5f;

    public Transform position;


    public Material fresnelMat;

    [HideInInspector]
    public bool isTrailActive;

    private SkinnedMeshRenderer[] _skinnedMeshRenderers;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isTrailActive)
        {
            StartCoroutine(TrailActive(activeTime));
        }
    }

    IEnumerator TrailActive(float timeActive)
    {
       
        while (timeActive>0)
        {
            timeActive -= meshRefreshRate;
            if (_skinnedMeshRenderers==null)
            {
                _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }

            for (int i = 0; i < _skinnedMeshRenderers.Length; i++)
            {
                GameObject gO = new GameObject();
                gO.transform.SetPositionAndRotation(position.position, position.rotation);


                MeshFilter mf=  gO.AddComponent<MeshFilter>();
                MeshRenderer mr= gO.AddComponent<MeshRenderer>();

                Mesh mesh = new Mesh();
                _skinnedMeshRenderers[i].BakeMesh(mesh);

                mf.mesh = mesh;
                mr.material = fresnelMat;

                Destroy(gO, meshDestroyDelay);
            }

            yield return new WaitForSeconds(meshRefreshRate);
        }
        isTrailActive = false;

    }
}
