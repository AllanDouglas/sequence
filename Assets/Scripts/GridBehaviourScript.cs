using UnityEngine;
using System.Collections;

public class GridBehaviourScript : MonoBehaviour {

	private const float ESPACAMENTO_ENTRE_PECAS = 1.02f;

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

	private Color32[] cores = new Color32[8];

	// inicializar
	public void Inicializar(){
		// incializa as cores
		cores[0] = new Color32();


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
				_grid [x, y].Colorir(Cores.GetInstance().Cor(x));
				_grid [x, y].Posicionar (x, y);
			}
		}


		//MoveLinhaDireita (0);
		//MoveLinhaEsquerda (1);

			Misturar ((colunas * linhas) / 2);

	}


	// misturar
	public void Misturar(int movimentos){

		Debug.Log (movimentos+" movimentos");
		int aux = 0;
		while (aux < movimentos) {
			// randomisa uma posicao no grid
			int _linha = Random.Range (0, this.linhas);
			int _coluna = Random.Range (0, this.colunas);
			// randomiza uma direcao
			int auxDirecao = Random.Range (0, 4);

			switch (auxDirecao) {
			case 0: // baixo

				Debug.Log ("Rodando coluna " + _coluna + " para baixo");

				MoveColunaBaixo (_coluna);
				break;
			case 1: // cima
				Debug.Log ("Rodando coluna " + _coluna + " para cima");
				MoveColunaCima (_coluna);
				break;
			case 2: // esquerda
				Debug.Log ("Rodando linha " + _linha + " para Esquerda");
				MoveLinhaEsquerda (_linha);
				break;
			case 3: // direita
				Debug.Log ("Rodando linha " + _linha + " para direita");
				MoveLinhaDireita (_linha);
				break;
			}

			aux++;

		}
	}
	// movimenta a coluna de acordo com a direcao passada
	public void MoveColunaCima(int coluna){


		ItemDoGridBehaviourScript itemAtual = _grid [coluna, 0];
		Vector2 posicaoItemInicial = itemAtual.transform.position;
		for(int i = 1; i<this.colunas;i++){

			ItemDoGridBehaviourScript itemTmp = _grid[coluna,i];
			_grid [coluna, i] = itemAtual;
			_grid [coluna,i].Posicionar (coluna,i);
			itemAtual.transform.position = itemTmp.transform.position;
			itemAtual = itemTmp;
		}
		itemAtual.transform.position = posicaoItemInicial;
		_grid[coluna,0] = itemAtual;
		itemAtual.Posicionar (coluna,0);

	}
	// movimenta a coluna de acordo com a direcao passada
	public void MoveColunaBaixo(int coluna){
		
		ItemDoGridBehaviourScript itemAtual = _grid [coluna, this.linhas - 1];
		Vector2 posicaoItemInicial = itemAtual.transform.position;
		for(int i = this.linhas - 2 ; i >= 0; i--){

			ItemDoGridBehaviourScript itemTmp = _grid[coluna,i];
			_grid [coluna, i] = itemAtual;
			_grid [coluna,i].Posicionar (coluna,i);
			itemAtual.transform.position = itemTmp.transform.position;
			itemAtual = itemTmp;
		}
		itemAtual.transform.position = posicaoItemInicial;
		_grid[coluna,this.linhas - 1] = itemAtual;
		itemAtual.Posicionar (coluna,this.linhas - 1);
	}

	// movimenta uma linha de acordo com a direcao passada
	public void MoveLinhaDireita(int linha){

		ItemDoGridBehaviourScript itemAtual = _grid [0,linha];
		Vector2 posicaoItemInicial = itemAtual.transform.position;
		for(int i = 1; i<this.linhas;i++){

			ItemDoGridBehaviourScript itemTmp = _grid[i,linha];
			_grid [i,linha] = itemAtual;
			_grid [i, linha].Posicionar (i, linha);
			itemAtual.transform.position = itemTmp.transform.position;
			itemAtual = itemTmp;
		}
		itemAtual.transform.position = posicaoItemInicial;
		_grid[0,linha] = itemAtual;
		itemAtual.Posicionar (0, linha);
	
	}

	// movimenta uma linha de acordo com a direcao passada
	public void MoveLinhaEsquerda(int linha){

		ItemDoGridBehaviourScript itemAtual = _grid [this.colunas - 1,linha];
		Vector2 posicaoItemInicial = itemAtual.transform.position;
		for(int i = this.colunas - 2; i>= 0;i--){

			ItemDoGridBehaviourScript itemTmp = _grid[i,linha];
			_grid [i,linha] = itemAtual;

			_grid [i, linha].Posicionar (i, linha);
			itemAtual.transform.position = itemTmp.transform.position;
			//StartCoroutine(Rolar(itemAtual.transform,itemTmp.transform.position));

			itemAtual = itemTmp;
		}
		itemAtual.transform.position = posicaoItemInicial;
		//StartCoroutine(Rolar(itemAtual.transform,posicaoItemInicial));
		_grid[this.colunas - 1,linha] = itemAtual;
		itemAtual.Posicionar (this.colunas - 1, linha);

	}
	// verifica se o grid está em ordem
	public bool EstaEmOrdem(){

		for (int x = 0; x < colunas; x++) {
			for (int y = 0; y < linhas -1 ; y++) {

				if (_grid [x, y].valor != _grid [x, y + 1].valor) {
					return false;
				}

			}
		}

		return true;

	}

	private IEnumerator Rolar(Transform de, Vector2 para){

		Debug.Log ("Inicio da rolagem de " + de);
		while (de.position.x != para.x && de.position.y != para.y) {
		
			de.position = Vector2.Lerp(de.position, para, 3 * Time.deltaTime);
			yield return null;
		}
		Debug.Log("Final da rolagem de "+de);
	
	}

}

