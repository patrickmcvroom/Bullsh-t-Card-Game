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
    [SerializeField] private Declaration _declaration;

    public delegate void DeclarationEventHandler(SObject source, EventArgs args);
    public event DeclarationEventHandler Declaration;
    
    private void Start()
    {
        showingQuantityButtons = false;
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
                _declaration.DeclaredRank = Rank.Ace;
                Debug.Log("Declared an " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "2":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Two;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "3":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Three;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "4":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Four;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "5":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Five;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "6":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Six;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "7":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Seven;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "8":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Eight;
                Debug.Log("Declared an " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "9":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Nine;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "10":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Ten;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "J":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Jack;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "Q":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.Queen;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "K":
                RemoveQuantityButtons();
                _declaration.DeclaredRank = Rank.King;
                Debug.Log("Declared a " + _declaration.DeclaredRank.ToString() + "!");
                StartCoroutine(DisplayQuantityButtons());
                break;
            case "x1":
                _declaration.DeclaredQuantity = 1;
                StartCoroutine(HideButtonDisplay());
                break;
            case "x2":
                _declaration.DeclaredQuantity = 2;
                StartCoroutine(HideButtonDisplay());
                break;
            case "x3":
                _declaration.DeclaredQuantity = 3;
                StartCoroutine(HideButtonDisplay());
                break;
            case "x4":
                _declaration.DeclaredQuantity = 4;
                StartCoroutine(HideButtonDisplay());
                break;
        }
    }
}