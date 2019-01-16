/************************************************************
************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
************************************************************/
public class Sin_material_tiling : MonoBehaviour {
	/****************************************
	****************************************/
	[System.Serializable]
	public class PARAM_TILE {
		public float Center;
		public float Amp;
		public float T;
		
		public PARAM_TILE(float _Center, float _Amp, float _T)
		{
			Center = _Center;
			Amp = _Amp;
			T = _T;
		}
	}
		
	/****************************************
	****************************************/
	Material sharedMaterial;
	
	[SerializeField] PARAM_TILE tile_x = new PARAM_TILE(5.0f, 2.5f, 15.0f);
	[SerializeField] PARAM_TILE tile_y = new PARAM_TILE(30.0f, 0.5f, 10.0f);
	
	/****************************************
	****************************************/
	
	/******************************
	******************************/
	void Start () {
		sharedMaterial = GetComponent<Renderer>().sharedMaterial;
	}

	/******************************
	******************************/
	void Update () {
		Vector2 scale = new Vector2(tile_x.Amp * Mathf.Cos(2 * Mathf.PI * (Time.realtimeSinceStartup / tile_x.T)) + tile_x.Center, tile_y.Amp * Mathf.Cos(2 * Mathf.PI * (Time.realtimeSinceStartup / tile_y.T)) + tile_y.Center);

		sharedMaterial.SetTextureScale("_MainTex", scale);
	}
}
