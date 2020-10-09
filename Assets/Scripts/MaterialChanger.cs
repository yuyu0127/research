using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Texture[] textures;
    public int textureId = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            textureId = (int) Mathf.Repeat(textureId + 1, textures.Length);
            targetMaterial.SetTexture("_BumpMap", textures[textureId]);
        }
    }
}