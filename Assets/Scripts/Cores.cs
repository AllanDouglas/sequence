using UnityEngine;
using System.Collections;

public class Cores
{

	private Color32[] cores;

	private static Cores instance = null;

	public static Cores GetInstance(){
		if (instance == null) {
			instance = new Cores ();
		}

		return instance;
	}
	/// <summary>
	/// Cor the specified index.
	/// </summary>
	/// <param name="index">Index.</param>
	public Color32 Cor(int index){

		if (index >= cores.Length) {
			return Color.red;
		}

		return cores [index];
	}

	private Cores(){

		cores = new Color32[8];

		cores [0] = GetRgb (255,230,128,255); // amarelo
		cores [1] = GetRgb (128,229,255,255); // azul
		cores [2] = GetRgb (255,128,128,255); // vermelho
		cores [3] = GetRgb (135,222,135,255); // verde


	}
	/// <summary>
	/// Gets the rgb.
	/// </summary>
	/// <returns>The rgb.</returns>
	/// <param name="r">The red component.</param>
	/// <param name="g">The green component.</param>
	/// <param name="b">The blue component.</param>
	/// <param name="a">The alpha component.</param>
	private Color32 GetRgb(byte r, byte g, byte b, byte a){	
		
		return new Color32 (r,g,b,a);
	}



}

