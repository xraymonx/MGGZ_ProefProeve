using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class FotoManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteTochange;

    private Bounds sizeOfSprites;
    [SerializeField]
    private Rect imageBookArea;
    private List<Texture2D> images = new List<Texture2D>();

    private string imageFolderPath = "";

    private void Start()
    {
        sizeOfSprites = spriteTochange.bounds;
        SearchForImageFolder();


    }

    private void SearchForImageFolder()
    {
        imageFolderPath = Path.GetFullPath(StringValues.FolderPath + "/" + "images");
        Debug.Log(imageFolderPath);

        StartCoroutine("LoadAll", Directory.GetFiles(imageFolderPath, "*.png", SearchOption.AllDirectories));


    }


    IEnumerator LoadAll(string[] filePaths)
    {

        foreach (string filePath in filePaths)
        {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            {
                images.Add(load.texture);
            }
        }

        Sprite newImageSprite = Sprite.Create(images[1], new Rect(0, 0, images[1].width, images[1].height), new Vector2(0.5f, 0.5f), 5000f);

        spriteTochange.sprite = newImageSprite;


    }
}
