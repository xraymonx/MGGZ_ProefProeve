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

    private List<Texture2D> images = new List<Texture2D>();
    private List<Sprite> sprites = new List<Sprite>();

    private string imageFolderPath = "";

    [SerializeField]
    private SaveAndLoadImage saveAndLoadImage;
    [SerializeField]private UITextFillFromData textFill;

    private int currentImage = 0;

    private void Start() {
        SearchForImageFolder();
    }

    public void NextImage(bool FlipPage) {
        if(FlipPage) {
            if(currentImage < images.Count) {
                textFill.SaveCurrentText(currentImage);
                currentImage++;
                LoadImageAndText(currentImage);

            }
        } else {
            if(currentImage > 0) {
                textFill.SaveCurrentText(currentImage);
                currentImage--;
                LoadImageAndText(currentImage);
            }
        }

    }
    private void SearchForImageFolder() {
        imageFolderPath = Path.GetFullPath(StringValues.FolderPath + "/" + "images");
        Debug.Log(imageFolderPath);

        StartCoroutine("LoadAll", Directory.GetFiles(imageFolderPath, "*.*", SearchOption.AllDirectories));


    }


    IEnumerator LoadAll(string[] filePaths) {

        foreach(string filePath in filePaths) {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if(!string.IsNullOrEmpty(load.error)) {
                Debug.LogWarning(filePath + " error");
            } else {
                images.Add(load.texture);
            }
        }
        CreateSpritesFromTextures();

    }
    private void CreateSpritesFromTextures() {
        foreach(Texture2D texture in images) {
            Sprite newImageSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 10000f);
            sprites.Add(newImageSprite);
        }
        LoadImageAndText(currentImage);
    }
    private void LoadImageAndText(int imageNumber) {        

        spriteTochange.sprite = sprites[imageNumber];
        textFill.FillText(imageNumber);


    }
}
