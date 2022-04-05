using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    [SerializeField] Renderer[] renderersToSwapMaterialsOn;

    public void SwapStartingMaterialsToTargetMaterial(Material materialToSwapTo)
    {
        foreach(Renderer targetRenderer in renderersToSwapMaterialsOn)
        {
            targetRenderer.material = materialToSwapTo;
        }
    }

}
