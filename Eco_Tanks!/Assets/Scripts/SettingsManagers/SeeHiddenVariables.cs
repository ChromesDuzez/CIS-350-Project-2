using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeHiddenVariables : MonoBehaviour
{
    public bool debug;
    [SerializeField]
    public List<KeyRef> allKeybindings = GlobalSettings.allKeybindings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(debug)
        {
            allKeybindings = GlobalSettings.allKeybindings;
        }
    }
}
