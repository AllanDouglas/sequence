using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InGameUIBehaviourScript : MonoBehaviour
{
	/// <summary>
	/// Labels
	/// </summary>
	[Header("Labels")]
	public Text movimentos;
	public Text tempo;

	[Header("Botoes")]
	public Button pauseButton;
	public Button restartButton;
	public Button menuButton;


	private StringBuilder movimentosString, tempoString;

	void Start(){

		movimentosString = new StringBuilder ();
		movimentosString.AppendFormat ("Movimentos: {0}", 0);

		tempoString = new StringBuilder ();	
		tempoString.AppendFormat ("Tempo: {0}:,{1:00}",0, 0);


		menuButton.onClick.AddListener (delegate {
			Menu ();
		});

	}


	public void Menu(){
	
		ControleDeCenas.CarregarCena ("start");
		
	}

	public void Movimentos(int movimentos){

		if (movimentosString == null) {
			tempoString = new StringBuilder ();	
			movimentosString.AppendFormat ("{0}", 0);
		}

		movimentosString.Remove (0, movimentosString.Length);
		movimentosString.AppendFormat ("{0}", movimentos);

		this.movimentos.text = movimentosString.ToString();

	}

	public void Tempo(int minutos, int segundos){

		if (tempoString == null) {
			tempoString = new StringBuilder ();	
			tempoString.AppendFormat ("{0}:{1:00}",0,0);
		}

		tempoString.Remove (0, tempoString.Length);
		tempoString.AppendFormat ("{0}:{1:00}",minutos, segundos);

		tempo.text = tempoString.ToString();

	}

}

