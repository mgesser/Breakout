using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        Manager.Instance.playerName = inputField.text;
    }

    private void Update()
    {
        Manager.Instance.playerName = inputField.text;
    }

    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }

}
