using UnityEngine;
using System.Collections;

public class LevelBehaviourScript : MonoBehaviour {

	public int linhas;
	public int colunas;

	public GameObject prefab; 

	public GridBehaviourScript Grid;

	// Use this for initialization
	void Start () {
		Grid.colunas = colunas;
		Grid.linhas = linhas;
		Grid.prefabDoPreenchimento = prefab;

		Grid.Inicializar ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
