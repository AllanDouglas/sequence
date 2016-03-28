using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreenBehaviourScript : MonoBehaviour
{


	public void Jogar(int blocos){

		int _quantidade = (int)Mathf.Sqrt (blocos);

		PlayerPrefs.SetInt ("_colunas_",_quantidade);
		PlayerPrefs.SetInt ("_linhas_",_quantidade);

		SceneManager.LoadScene ("main");
	}

}

