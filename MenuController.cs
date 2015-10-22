using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public static MenuController _instance;

	public SkinnedMeshRenderer headRenderer;
	public Mesh[] headMeshArray;
	private int headMeshIndex = 0;

	public SkinnedMeshRenderer handRenderer;
	public Mesh[] handMeshArray;
	private int handMeshIndex = 0;

	private Color[] colorArray;
	private int colorIndex = -1;

	public SkinnedMeshRenderer[] bodyArray;

	void Awake() {
		_instance = this;
	}

	void Start() {
		colorArray = new Color[] { Color.blue, Color.red };
		DontDestroyOnLoad(this.gameObject);
	}

	public void OnHeadMeshNext() {
		headMeshIndex++;
		headMeshIndex %= headMeshArray.Length;
		headRenderer.sharedMesh = headMeshArray[headMeshIndex];
	}
	public void OnHandMeshNext() {
		handMeshIndex++;
		handMeshIndex %= handMeshArray.Length;
		handRenderer.sharedMesh = handMeshArray[handMeshIndex];
	}

	public void OnChangeColorBlue() {
		colorIndex = 0;
		OnChangeColor(Color.blue);
	}

	public void OnChangeColorRed() {
		colorIndex = 1;
		OnChangeColor(Color.red);
	}

	void OnChangeColor(Color c) {
		foreach (SkinnedMeshRenderer renderer in bodyArray) {
			renderer.material.color = c;
		}
	}

	void Save() {
		PlayerPrefs.SetInt("HeadMeshIndex",headMeshIndex);
		PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
		PlayerPrefs.SetInt("ColorIndex", colorIndex);
	}

	public void OnPlay() {
		Save();
		Application.LoadLevel(1);
	}
}
