using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Animator))]

public class LevelClearUiBehaviourScript : MonoBehaviour
{
	[Header("Labels")]
	public Text TempoFinal;
	public Text movimentos;

	/// <summary>
	/// Desabilita o animator
	/// </summary>
	public void ParaAnimacao(){

		GetComponent<Animator> ().enabled = false;
	
	}



}

