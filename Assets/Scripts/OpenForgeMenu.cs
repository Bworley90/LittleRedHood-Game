using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenForgeMenu : MonoBehaviour
{
    private Animator anim;
    public bool nearForge;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearForge == true)
        {
            anim.SetBool("isOpen", true);
        }
        else if (nearForge == false)
        {
            anim.SetBool("isOpen", false);
        }
        
    }
}
