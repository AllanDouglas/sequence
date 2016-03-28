using UnityEngine;
using System;
using System.Collections;

public class LevelBehaviourScript : MonoBehaviour {




	/// <summary>
	/// Montagem do Grid
	/// </summary>
	public int linhas;
	public int colunas;
	public ItemDoGridBehaviourScript prefab; 
	public GridBehaviourScript Grid;
	/// <summary>
	/// The audio source fx.
	/// </summary>
	public AudioSource audioSourceFx;
	/// <summary>
	/// UI's
	/// </summary>
	public LevelClearUiBehaviourScript LevelClearUi;
	public InGameUIBehaviourScript InGameUi;
	[Header("Audio clips")]
	public AudioClip movimentoAudioClip;

	/// <summary>
	/// Quantidade de movimentos feitos pelo jogador
	/// </summary>
	private int movimentos = 0;
	/// <summary>
	/// Controle to tempo em segundos
	/// </summary>
	private float tempo = 0;

	private bool jogando = true;

	// Use this for initialization
	void Start () {
		
		linhas  = PlayerPrefs.GetInt ("_linhas_");
		colunas = PlayerPrefs.GetInt ("_colunas_");

		Inicializar ();
	}
	/// <summary>
	/// Configurações inicias do game
	/// </summary>
	private void Inicializar(){
		//desetiva as Uis desnessessárias 
		LevelClearUi.gameObject.SetActive (false);

		StartCoroutine (Cronometro());

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

	private IEnumerator Cronometro(){

		while (jogando) {

			tempo += 1;
			/*
			Debug.Log ("Tempo "+tempo);
			Debug.Log ("Munutos " +(int) (tempo / 60));
			Debug.Log ("Segundos " + (int) (tempo % 60));
			*/

			InGameUi.Tempo((int)(tempo / 60),(int) (tempo % 60));

			yield return new WaitForSeconds(1);

		}

	}

	/// <summary>
	/// Escuta o evento de quando termina o toque	
	/// </summary>
	/// <param name="item">Item.</param>
	/// <param name="direcao">Direcao.</param>
	private void TouchObserver(ItemDoGridBehaviourScript item, TouchBehaviourScript.Direcao direcao){

		if (jogando) {
			//toca o som da movimentação
			this.audioSourceFx.PlayOneShot (this.movimentoAudioClip);

			// incrementa a quantidade de movimentos
			movimentos++;
			InGameUi.Movimentos(movimentos);

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
			// Verifica se o grid está em ordem
			if (Grid.EstaEmOrdem ())
				Vencer ();

		}


	}

	/// <summary>
	/// Vence o game
	/// </summary>
	public void Vencer(){
		// para o game
		jogando = false;

		//DateTime data = new DateTime (Time.time);
		//string tempo = string.Format("{0}:{1}",data.Minute,data.Second);
		LevelClearUi.TempoFinal.text = string.Format ("{0}:{1:00}",(int) (tempo / 60),(int) (tempo % 60));
		LevelClearUi.movimentos.text = movimentos.ToString();
		LevelClearUi.gameObject.SetActive (true);

	}


	/// <summary>
	/// Raises the destroy event.
	/// </summary>
	void OnDestroy(){
		// remove o evento
		TouchBehaviourScript.QuandoTerminar -= TouchObserver;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ControleDeCenas.CarregarCena ("start");
		}

	}




}
