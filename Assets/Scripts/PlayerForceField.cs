using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceField : MonoBehaviour
{
    Transform bodyTransform;
    Transform forceFieldTransform;
    Transform spheereTransform;

    MeshRenderer sphereMeshRenderer;
    Material speedFieldMaterial;
    Material forceFieldMaterial;


    // Start is called before the first frame update
    void Start()
    {
        bodyTransform = transform.Find("body");
        forceFieldTransform = bodyTransform.transform.Find("ForceField");
        spheereTransform = forceFieldTransform.transform.Find("Sphere");

        sphereMeshRenderer = spheereTransform.GetComponent<MeshRenderer>();
        speedFieldMaterial = Resources.Load<Material>("Materials/Speedfield_material");
        forceFieldMaterial = Resources.Load<Material>("Materials/Forcefield_material");

        forceFieldTransform.gameObject.SetActive(GameData.ExtraForceTimeout > 0 || GameData.ExtraSpeedTimeout > 0);

        StartCoroutine(ExtraForceTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ExtraForceTimer()
    {
        //UnityEngine.Debug.Log("GameController.ExtraForceTimer started...");
        while (true)
        {
            //UnityEngine.Debug.Log("Tick " + GameData.ExtraForceTimeout + " sec");
            if (GameData.ExtraSpeedTimeout > 0)
            {
                sphereMeshRenderer.material = speedFieldMaterial;
                yield return new WaitForSeconds(1);
            }

            if (GameData.ExtraForceTimeout > 0)
            {
                sphereMeshRenderer.material = forceFieldMaterial;
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(1);

            forceFieldTransform.gameObject.SetActive(GameData.ExtraForceTimeout > 0 || GameData.ExtraSpeedTimeout > 0);
        }

        //UnityEngine.Debug.Log("...GameController.ExtraForceTimer ended");
    }

    private void OnDestroy()
    {
        StopCoroutine(ExtraForceTimer());
    }

}
