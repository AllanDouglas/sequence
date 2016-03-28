using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControleDeCenas 
{

	public static void CarregarCena(string cena){

		SceneManager.LoadScene (cena);

	}

}

