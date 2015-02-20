using UnityEngine;
using System.Collections;

[RequireComponent(typeof (GUITexture))]
public class Button : MonoBehaviour {

	//ボタンのテクスチャ
	public Texture2D ButtonTexture;//ボタンを離している時に表示されるテクスチャ
	public Texture2D PushedTexture;//ボタンを押した時に表示されるテクスチャ

	//テクスチャの画面に対する倍率
	public float prefix;

	/*ボタンの表示位置
	xは0.0=左端 1.0=右端
	yは0.0=下端 1.0=上端
	両方0.5にしたら画面真ん中になる
	 */
	public Vector2 TexturePosition;

	private float Size;
	private GUITexture gui;
	private Rect defaultRect;

	// Use this for initialization
	void Start () {

		gui = GetComponent<GUITexture>();

		//画面サイズからテクスチャの倍率を算出
		Size = (Screen.width * prefix) * 100;


		//GUITextureのテクスチャをButtonTextureのテクスチャに差し替え
		gui.texture = ButtonTexture;

		defaultRect =  gui.pixelInset;

		//画面に描画されるテクスチャのサイズを計算
		//この処理が必要な理由はUnityのGUIシステムが解像度ごとに画像をスケーリングしてくれないため
		defaultRect.width =  Size / gui.texture.width;
		defaultRect.height = Size / gui.texture.height;


		/*
		テクスチャの描画位置を設定
		TexturePosition.x * Screen.widthでは「計算された位置を起点にしてテクスチャを張る」ので
		TexturePositionを0.5(画面中央)に設定してもズレてしまうので
		((Size / gui.texture.width) / 2) つまり描画されるテクスチャサイズの半分を引いて計算すると
		ぴったり真ん中に合うようになる
		 */
		defaultRect.x = (TexturePosition.x * Screen.width) - ((Size / gui.texture.width) / 2);
		defaultRect.y = (TexturePosition.y * Screen.height) - ((Size / gui.texture.height) / 2);

		//計算結果をGUITextureのプロパティに反映
		gui.pixelInset = defaultRect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		/*
		ボタンをタップした時にGUITextureのテクスチャをPushedTextureのテクスチャに差し替え
		OnMouseDownはスマートフォンの画面タップに対しても使える
		 */
		gui.texture = PushedTexture;
	}

	void OnMouseUp(){
		/*
		 ボタンを離した時にGUITextureのテクスチャをButtonTextureのテクスチャに戻す
		 */
		gui.texture = ButtonTexture;
	}
}

