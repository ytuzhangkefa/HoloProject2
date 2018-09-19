using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		RaycastHit hitInfo;
		if (Physics.Raycast(
               Camera.main.transform.position,
               Camera.main.transform.forward,
               out hitInfo,
               20.0f,
               Physics.DefaultRaycastLayers))
		{
            //hitInfo.collider.transform.Rotate(Vector3.up);
            if (hitInfo.collider.gameObject.name == "Plane")
            {
                Vector2 uv = hitInfo.textureCoord;

                Material mat = hitInfo.transform.GetComponent<Renderer>().material;
                Texture2D tex = mat.mainTexture as Texture2D;
                Color color = tex.GetPixel((int)(uv.x * tex.width), (int)(uv.y * tex.height));
                GameObject.Find("Cube").GetComponent<Renderer>().material.color = color;
            }
            
		}
		else
		{
			
		}
	}
}
