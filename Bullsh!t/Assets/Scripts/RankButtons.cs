using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TrueGames.Bullshit;
using TrueGames.Bullshit.DataModels;
using SObject = System.Object;


public class RankButtons : MonoBehaviour
{
    private Quaternion _buttonRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    public bool showingQuantityButtons;

    [SerializeField] private TrueGamesButton _rankButtonPrefab;
    [SerializeField] private TrueGamesButton _quantityButtonPrefab;
    //[SerializeField] private Declaration _declaration;
    [SerializeField] private DeclarationRenderer _declarationRenderer;

    public delegate void CardsDeclaredEventHandler(SObject source, EventArgs args);
    public event CardsDeclaredEventHandler CardsDeclared;
    
    private void Awake()
    {
        showingQuantityButtons = false;
        CardsDeclared += _declarationRenderer.OnCardsDeclared;
    }

    private IEnumerator HideButtonDisplay()
    {
        var children = new GameObject[transform.childCount];

        var i = 0;

        foreach (Transform child in transform)
        {
            children[i] = child.gameObject;
            i++;
        }

        foreach (var child in children)
        {
            Destroy(child.gameObject);
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void CreateRankButton(Vector3 buttonPosition, string buttonText)
    {
        var button = Instantiate(_rankButtonPrefab, buttonPosition, _buttonRotation, transform);
        button.Text.text = buttonText;
        button.GetComponent<Image>().color = new Color(0.9f, 0.9f, 0.9f);
        button.SetClickAction(Declare);
    }

    public void CreateQuantityButton(Vector3 buttonPosition, Color buttonColor, string buttonText)
    {
        var button = Instantiate(_quantityButtonPrefab, buttonPosition, _buttonRotation, transform);
        button.Text.text = buttonText;
        button.GetComponent<Image>().color = buttonColor;
        button.SetClickAction(Declare);
    }

    public void RemoveQuantityButtons()
    {
        if(showingQuantityButtons == true)
        {
            var children = new GameObject[transform.childCount];

            var i = 0;

            foreach (Transform child in transform)
            {
                children[i] = child.gameObject;
                i++;
            }

            foreach (var child in children)
            {
                if(child.name == "Quantity Button(Clone)")
                {
                    Destroy(child.gameObject);
                }
            }

            showingQuantityButtons = false;
        }
    }

    public IEnumerator DisplayQuantityButtons()
    {
        if(showingQuantityButtons == false)
        {
            string[] quantityBtnTextArray = { "x1", "x2", "x3", "x4" };

            Color[] quantityBtnColorArray = { new Color(1f, 0.98f, 0.76f), new Color(1f, 0.94f, 0.31f), new Color(1f, 0.71f, 0f), new Color(1f, 0.29f, 0.29f) };

            var buttonStartPosition = new Vector3(-35f, 30f, 0f);
            // buttonStartPosition.x = Input.mousePosition.x;

            for (int i = 0; i < quantityBtnTextArray.Length; i++)
            {
                CreateQuantityButton(buttonStartPosition, quantityBtnColorArray[i], quantityBtnTextArray[i]);
                buttonStartPosition.x += 23f;
                yield return new WaitForSeconds(0.05f);
            }

            showingQuantityButtons = true;
        }
    }

    public void Declare(string param)
    {
        switch (param)
        {
            case "A":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Ace;
                Debug.Log("Declared an " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "2":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Two;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "3":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Three;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "4":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Four;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "5":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Five;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "6":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Six;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "7":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Seven;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "8":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Eight;
                Debug.Log("Declared an " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "9":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Nine;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "10":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Ten;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "J":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Jack;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "Q":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.Queen;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "K":
                RemoveQuantityButtons();
                Declaration.DeclaredRank = Rank.King;
                Debug.Log("Declared a " + Declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "x1":
                Declaration.DeclaredQuantity = 1;
                OnCardsDeclared();
                StartCoroutine(HideButtonDisplay());
                break;
            case "x2":
                Declaration.DeclaredQuantity = 2;
                OnCardsDeclared();
                StartCoroutine(HideButtonDisplay());
                break;
            case "x3":
                Declaration.DeclaredQuantity = 3;
                OnCardsDeclared();
                StartCoroutine(HideButtonDisplay());
                break;
            case "x4":
                Declaration.DeclaredQuantity = 4;
                OnCardsDeclared();
                StartCoroutine(HideButtonDisplay());
                break;
        }
    }

    protected virtual void OnCardsDeclared()
    {
        CardsDeclared?.Invoke(this, EventArgs.Empty);
    }
}