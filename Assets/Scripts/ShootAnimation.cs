using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnimation : MonoBehaviour
{

   public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    public void animate()
    {
        anim.SetTrigger("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
