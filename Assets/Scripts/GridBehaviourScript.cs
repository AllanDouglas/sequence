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
	public ItemDoGridBehaviourScript prefabDoPreenchimento;


	// array do grid deve
	private ItemDoGridBehaviourScript[,] _grid;


	// inicializar
	public void Inicializar(){
		this._grid = new ItemDoGridBehaviourScript[this.colunas,this.linhas];

		// posiciona a camera
		float aux = (colunas - 1) / 2.0f;
		aux *= ESPACAMENTO_ENTRE_PECAS;
		Camera.main.transform.position = new Vector3(aux, (linhas -1 ) /2, -10);
		Camera.main.orthographicSize = colunas + 1;

		for (int x = 0; x < colunas; x++) {
			for (int y = 0; y < linhas; y++) {

				_grid [x, y] = Instantiate (prefabDoPreenchimento); 
				_grid [x, y].transform.position = new Vector2 (x * ESPACAMENTO_ENTRE_PECAS,y * ESPACAMENTO_ENTRE_PECAS);
				_grid [x, y].transform.parent = transform;
				_grid [x, y].label.text = (x + 1).ToString();
				_grid [x, y].valor = x + 1;
			}
		}

	}


	// misturar


}
