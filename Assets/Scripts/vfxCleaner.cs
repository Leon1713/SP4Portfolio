using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class vfxCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    private VisualEffect vfx;
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vfx.aliveParticleCount == 0 )
        {
            Destroy(gameObject,0.3f);
        }
    }
}
