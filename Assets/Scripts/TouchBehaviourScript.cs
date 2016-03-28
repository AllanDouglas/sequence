using UnityEngine;
using System.Collections;

public class TouchBehaviourScript : MonoBehaviour {
	// Direcao do toque
	public enum Direcao
	{
		CIMA, BAIXO, DIRETA, ESQUERDA
	}

	public delegate void Toque(ItemDoGridBehaviourScript item, Direcao direcao);

	public static event Toque QuandoTerminar; // disparaddo quando o evento de toque é completado

	[Header("Lista dos nomes das camadas que serão tocaveis")]
	public string[] camadas;

	// posicao do primeiro toque
	private Vector2 posicaoInicial;
	// flag para marcar o inicio do toque
	private bool toqueIniciado = false;

	private ItemDoGridBehaviourScript itemDoGrid; // item inicialmente tocado
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR  
			ToquePC();		 
		#elif UNITY_ANDROID
			ToqueMobile();		
		#elif UNITY_WINRT_8_1
			ToqueMobile();		
		#elif UNITY_WEBGL
			ToquePC();		
		#endif




	}

	private void ToquePC(){
		// tocou com o botão esqquerdo
		if(Input.GetMouseButtonDown(0) & toqueIniciado == false){
			// verifica se tocou 
			Vector2 toque = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(VerificaToque(toque)){

				Inicio(toque);
			}
		}
		//soltou o botão esquerdo
		if(Input.GetMouseButtonUp(0) & toqueIniciado == true){
			toqueIniciado = false;
			Vector2 toque = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if( Vector2.Distance(posicaoInicial,toque) > 0.5f ){
				//&& VerificaToque(toque)
				Finalizar(toque);
			}
		}
	
	}

	private void ToqueMobile(){
		// inicio do toque
		if(Input.touchCount > 0 && toqueIniciado 
			== false & Input.GetTouch(0) .phase == TouchPhase.Began){
			// verifica se tocou 
			Vector2 toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if(VerificaToque(toque)){

				Inicio(toque);
			}
		}
		// soltar o toque
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended & toqueIniciado == true){
			toqueIniciado = false;
			Vector2 toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if( Vector2.Distance(posicaoInicial,toque) > 1 ){
				//&& VerificaToque(toque)
				Finalizar(toque);
			}
		}		
	}

	private bool VerificaToque(Vector2 posicao){
		// faz o raycast
		RaycastHit2D hit = Physics2D.Raycast (posicao, posicao, 0, LayerMask.GetMask (camadas));

		Debug.Log (hit.collider);

		// verifica se tocou em alguma coisa
		if (hit.collider != null) {
			// verifica se o te
			itemDoGrid = hit.transform.GetComponent<ItemDoGridBehaviourScript> ();
			//if (itemDoGrid)

			return true;

		}

		return false;
	}

	private void Inicio(Vector2 posicao){
		Debug.Log ("Toque iniciado");
		toqueIniciado = true;
		posicaoInicial = posicao;
	}

	private void Finalizar(Vector2 posicao){
		
		Direcao direcao; // direcao final

		// obtem a diferença entre as posicoes
		float x = posicao.x - posicaoInicial.x;
		float y = posicao.y - posicaoInicial.y;
		// veririca se o movimento vai ser na linhas ou coluna
		if (Mathf.Abs (x) > Mathf.Abs (y)) {
			// linha
			// agora define se esquerda ou direita
			if (posicao.x > posicaoInicial.x) {
				// direita	
				direcao = Direcao.DIRETA;
			} else {
				// esquerda
				direcao = Direcao.ESQUERDA;
			}

		} else {
			// coluna
			//agora define se é cima ou baixo
			if (posicao.y > posicaoInicial.y) {
				//cima
				direcao = Direcao.CIMA;
			} else {
				//baixo
				direcao = Direcao.BAIXO;
			}

		}

		Debug.Log (direcao);

		if(QuandoTerminar != null)
			QuandoTerminar (itemDoGrid,direcao);

	}

}
