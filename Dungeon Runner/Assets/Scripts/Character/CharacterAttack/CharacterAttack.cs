using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Animations.Rigging
{
    public class CharacterAttack : MonoBehaviour
    {
        public TwoBoneIKConstraint iK;
        public float coolDownTime;
        bool _reached=false;
        public GameObject knife;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!_reached)
            {
                iK.weight = Mathf.MoveTowards(iK.weight, 1f, 5f * Time.deltaTime);
                if (iK.weight==1f)
                {
                    _reached = true;
                    //knife.SetActive(false);
                }
            }
            else
            {
                iK.weight = Mathf.MoveTowards(iK.weight, 0f, 5f * Time.deltaTime);
                if (iK.weight == 0f)
                {
                    _reached = false;
                    //knife.SetActive(true);
                }
            }
        }
            
        

        IEnumerator ThrowKnife()
        {
            yield return new WaitForSeconds(coolDownTime);
        }
    }
}

