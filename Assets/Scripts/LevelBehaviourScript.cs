using UnityEngine;
using System.Collections;

public class LevelBehaviourScript : MonoBehaviour {

	public int linhas;
	public int colunas;

	public ItemDoGridBehaviourScript prefab; 

	public GridBehaviourScript Grid;

	// Use this for initialization
	void Start () {
		Inicializar ();
	}

	private void Inicializar(){
		// define o tamanho do grid
		Grid.colunas = colunas;
		Grid.linhas = linhas;
		// define o prefab
		Grid.prefabDoPreenchimento = prefab;
		// inicializa o grid
		Grid.Inicializar ();



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
