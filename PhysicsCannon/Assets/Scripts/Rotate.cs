using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotate : MonoBehaviour
{
    public Rigidbody cannon;
    private UIDocument UIdoc;
    private Button startBtn;

    private void Awake()
    {
        UIdoc = GetComponent<UIDocument>();
        startBtn = UIdoc.rootVisualElement.Q<Button>("bt_start");
        startBtn.clicked += StartButtonOnClicked;
    }

    void StartButtonOnClicked()
    {
        cannon.angularVelocity = new Vector3(0, 10, 0);
        StartCoroutine(Delay());
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
    }

    private void FixedUpdate()
    {
        cannon.transform.Rotate(Vector3.forward);
    }

    //private void OnEnable()
    //{
    //    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    //    Button buttonStart = root.Q<Button>("bt_start");
    //    Button buttonControls = root.Q<Button>("bt_controls");
    //    Button buttonExit = root.Q<Button>("bt_exit");

    //    buttonStart.clicked += () => cannon.transform.Rotate(Vector3.up);
    //}


}
