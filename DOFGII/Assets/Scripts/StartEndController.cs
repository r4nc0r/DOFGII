using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartEndController : MonoBehaviour {


    public static int level=0;
    public Material[] Skyboxes;
    public Text LevelText;

    void Awake()
    {
        level++;
        RenderSettings.skybox = Skyboxes[(int)Random.Range(0, 3)];
        Cursor.visible = false;
    }

    // Use this for initialization
    void Start () {
        LevelText.text = "Level " + level.ToString();
        PositionTextElement(LevelText, 0, -54, 600, 300);
        StartCoroutine(DelayedStart(5));
    }

    void PositionTextElement(Text TextElement, int posX, int posY, int sizeX, int sizeY)
    {
        LevelText.rectTransform.anchoredPosition = new Vector2(posX, posY);
        LevelText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeX);
        LevelText.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sizeY);
    }

	IEnumerator DelayedStart(int time)
    {
        yield return new WaitForSeconds(time);
        PositionTextElement(LevelText, 0, 0, 100, 50);
        this.gameObject.GetComponent<EnemyController>().enabled = true;
        
    }
}
