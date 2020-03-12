using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMat : MonoBehaviour
{
    public MeshFilter barrelMesh;
    public MeshFilter ringMesh;
    public MeshRenderer barrelMat;
    public MeshRenderer ringMat;
    public MeshRenderer wheelMat;
    public Mesh[] cannonMeshes;
    public Mesh[] ringMeshes;
    public Material[] cannonMaterials;
    public Material[] ringMaterials;
    public Material[] wheelMaterials;

    // Start is called before the first frame update
    void Start()
    {
        barrelMesh.mesh = cannonMeshes[ShopCamera.selectedCannon];
        barrelMat.material = cannonMaterials[ShopCamera.selectedCannon];

        ringMesh.mesh = ringMeshes[ShopCamera.selectedCannon];
        ringMat.material = ringMaterials[ShopCamera.selectedCannon];

        wheelMat.material = wheelMaterials[ShopCamera.selectedCannon];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
