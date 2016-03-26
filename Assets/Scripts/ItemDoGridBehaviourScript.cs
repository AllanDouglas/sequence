using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]

public class ItemDoGridBehaviourScript : MonoBehaviour {

	// sprite
	public SpriteRenderer spriteRenderer;
	// text label
	public TextMesh label;
	// valor
	public int valor;


	// posicionamento
	private int _x, _y;

	public int Y{
		get { return _y; }
	}

	public int X{
		get { return _x; }
	}


	/**
	 * Posiciona o item dentro do tabuleiro
	*/
	public void Posicionar(int x, int y){
		this._x = x;
		this._y = y;

		gameObject.name = string.Format ("{0},{1}",x,y);

	}

	// Use this for initialization
	void Start () {
		//configura a tag do game object
		gameObject.tag = "ItemDoGrid";
		//configura a camada
		gameObject.layer = LayerMask.NameToLayer("ItemDoGrid");

		// configura o box collider para objeto
		BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
		box.size.Set (1, 1);
		box.isTrigger = true;

	}


	public void Colorir(Color32 cor){	
		spriteRenderer.color = cor;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
