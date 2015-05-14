using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class texture : MonoBehaviour {
	public int index;
	private string defCode = "R9 G9 B9 Y9";
	private Texture text;

	// Use this for initialization
	void Start () {
		string filePath = Application.persistentDataPath + "/Code.txt";

		string code = readTextFile(filePath);
		if (code == "" || code == null){
			code = defCode;
		}
		string[] entries = code.Split(' ');
		Debug.Log (entries[index]);
		text = Resources.Load (entries[index]) as Texture2D;

		this.GetComponent<Renderer> ().material.mainTexture = text;


	}

	private string readTextFile(string file_path)
	{	
		string line = "";

		try{
			StreamReader stm = new StreamReader(file_path);
			while(!stm.EndOfStream)
			{
				line = stm.ReadLine( );
				// Do Something with the input. 
			}

			return line;
			stm.Close( );  
		}catch (Exception e){
			Debug.Log("File not found");
			return line;
		}
	}



}
