using UnityEngine;
using System.Collections;

public class LevelBehaviourScript : MonoBehaviour {

	public int linhas;
	public int colunas;

	public ItemDoGridBehaviourScript prefab; 

	public GridBehaviourScript Grid;

	/// <summary>
	/// Quantidade de movimentos feitos pelo jogador
	/// </summary>
	private int movimentos;

	// Use this for initialization
	void Start () {
		Inicializar ();
	}
	/// <summary>
	/// Configurações inicias do game
	/// </summary>
	private void Inicializar(){
		// define o tamanho do grid
		Grid.colunas = colunas;
		Grid.linhas = linhas;
		// define o prefab
		Grid.prefabDoPreenchimento = prefab;
		// inicializa o grid
		Grid.Inicializar ();

		// evento que escuta a saida do touch

		TouchBehaviourScript.QuandoTerminar += TouchObserver;

	}
	/// <summary>
	/// Escuta o evento de quando termina o toque	
	/// </summary>
	/// <param name="item">Item.</param>
	/// <param name="direcao">Direcao.</param>
	private void TouchObserver(ItemDoGridBehaviourScript item, TouchBehaviourScript.Direcao direcao){
	
		switch (direcao) {
		case TouchBehaviourScript.Direcao.BAIXO:
			Grid.MoveColunaBaixo (item.X);
			break;
		case TouchBehaviourScript.Direcao.CIMA:
			Grid.MoveColunaCima (item.X);
			break;
		case TouchBehaviourScript.Direcao.ESQUERDA:
			Grid.MoveLinhaEsquerda (item.Y);
			break;
		case TouchBehaviourScript.Direcao.DIRETA:
			Grid.MoveLinhaDireita (item.Y);
			break;

		}



	}




	void OnDestroy(){
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
