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
        if(nearForge == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && anim.GetBool("isOpen") == false)
            {
                anim.SetBool("isOpen", true);
            }
            else if (Input.GetKeyDown(KeyCode.F) && anim.GetBool("isOpen") == true)
            {
                anim.SetBool("isOpen", false);
            }
        }
        
    }
}
