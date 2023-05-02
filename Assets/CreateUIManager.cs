using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class CreateUIManager : MonoBehaviour
{
      //PUBLIC VARIABLES FOR AFB
    /*  
    public enum FabANIM { VerticallyUp, CircleQuadrant };
    public FabANIM FABType;
    */
    public Button MainButton;
    public GameObject ButtonPrefab;
    public Sprite Back;
    public Sprite Menu;

    [System.Serializable]
    public class ButtonInfo
    {
        public Sprite sprite;
        public UnityEvent ButtonEvent;
    }
    public ButtonInfo[] ButtonCount2To6;


    //private variables of AFB
    int NoButton;
    bool expand = true;

    //VARIABLES FOR VERTICAL ANIM
    bool place = false;
    bool goDown = false;
    List<GameObject> selected = new List<GameObject>();
    int mov = 0;
    float t = 0;
    public float ButDis = 50f;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
            NoButton = ButtonCount2To6.Length; 
            InitializeVertical();
            MainButton.onClick.AddListener(VerticallyUp);
    }

   void Update()
    {
        if (place)
        {
            t = t + Time.deltaTime;
            float distance = Vector2.Distance(selected[mov].transform.position, target.transform.position + new Vector3(0, -Screen.height/8, 0));


            if (distance > 0.1f)
                selected[mov].transform.position = Vector3.Lerp(selected[mov].transform.position, new Vector3(target.transform.position.x, target.transform.position.y - Screen.height / 8, target.transform.position.z), t);
            else
            {
                if (mov < NoButton - 1)
                {
                    Debug.Log(selected[mov].name);
                    target = selected[mov];
                    mov += 1;
                    t = 0;
                }
                else
                {
                    Debug.Log("activating child");
                    foreach (Transform child in MainButton.transform)
                        child.gameObject.GetComponent<Button>().interactable = true;
                    place = false;
                }

            }
            // Debug.Log("mov :" + mov + " place :" + place + " dis :" + distance + " target pos : " + target.transform.position.y + ButDis);

        }

        if(goDown)
        {
            t = t + Time.deltaTime;
            float distance = Vector2.Distance(selected[mov].transform.position, MainButton.gameObject.transform.position);


            if (distance > 0.1f)
                selected[mov].transform.position = Vector3.Lerp(selected[mov].transform.position, MainButton.gameObject.transform.position, t);
            else
            {
                selected[mov].SetActive(false);
                if (mov > 0)
                {

                    mov -= 1;

                    t = 0;
                }
                else
                {
                    goDown = false;
                   

                }
            }
        }
    }
 
    void VerticallyUp()
    {
        if (expand)
        {
            foreach (Transform child in MainButton.transform)
                child.gameObject.SetActive(true);
            place = true;
            expand = false;
            MainButton.gameObject.GetComponent<Image>().sprite = Back;


        }
        else
        {
            MainButton.gameObject.GetComponent<Image>().sprite = Menu;
            mov = NoButton - 1;
            foreach (Transform child in MainButton.transform)
            {
                child.gameObject.GetComponent<Button>().interactable = false;
            }

            expand = true;
            goDown = true;
     
        }
    }

    void InitializeVertical()
    {
       
        for (int i = 0; i < NoButton; i++)
        {
            GameObject go = Instantiate(ButtonPrefab, MainButton.transform.position, Quaternion.identity);
            Debug.Log("gameobject created");
            go.GetComponent<Image>().sprite = ButtonCount2To6[i].sprite;
            go.name = i.ToString();
           

            go.GetComponent<Button>().onClick.AddListener(() =>
            {
                int j = int.Parse(go.name);
                ButtonCount2To6[j].ButtonEvent.Invoke();
            });
            go.transform.SetParent(MainButton.transform);
            go.transform.localScale = MainButton.gameObject.transform.localScale;
            selected.Add(go);
        }
        foreach (Transform child in MainButton.transform)
        {
            child.gameObject.GetComponent<Button>().interactable = false;
            child.gameObject.SetActive(false);

        }
        Debug.Log("Sel" + selected.Count);
        target = MainButton.gameObject;
    }
}
