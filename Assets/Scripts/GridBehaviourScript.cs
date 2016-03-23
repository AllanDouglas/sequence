using UnityEngine;
using System.Collections;

public class GridBehaviourScript : MonoBehaviour {

	private const float ESPACAMENTO_ENTRE_PECAS = 1.1f;

	// tamanho do grid
	[HideInInspector]
	public int linhas, colunas;
	// quantidade de movimentos para misturar 
	[HideInInspector]
	public int movimentos; 
	// prefab para preenchimento do grid
	[HideInInspector]
	public GameObject prefabDoPreenchimento;


	// array do grid deve
	private GameObject[,] _grid;


	// inicializar
	public void Inicializar(){
		this._grid = new GameObject[this.colunas,this.linhas];

		for (int x = 0; x < colunas; x++) {
			for (int y = 0; y < linhas; y++) {

				_grid [x, y] = Instantiate (prefabDoPreenchimento); 
				_grid [x, y].transform.position = new Vector2 (x * ESPACAMENTO_ENTRE_PECAS,y * ESPACAMENTO_ENTRE_PECAS);
				_grid [x, y].transform.parent = transform;
			}
		}

	}


	// misturar


}
