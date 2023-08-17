using UnityEngine;

public class DevModeMenu : MonoBehaviour
{
    [Header("Dev Canvas")]
    [Space]
    public GameObject DevCanvas;

    [Header("Player Obj")]
    [Space]
    public GameObject Player;

    [SerializeField]
    [Space]
    private int Counter;

    [Header("Lvl Obj")]
    [Space]
    public GameObject Lvl11;
    public GameObject Lvl22;
    public GameObject Lvl33;
    public GameObject Lvl44;
    public GameObject Lvl55;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Counter++;
            if (Counter == 5)
            {
                DevCanvas.SetActive(true);
                Cursor.visible = true;
            }
        }

        if (Counter >= 5)
        {
            Counter = 5;
        }

        if(Input.GetKeyDown(KeyCode.Equals))
        {
            DevCanvas.SetActive(false);
            Cursor.visible = false;
            Counter = 0;
        }
    }

    public void Lvl1()
    {
        Player.transform.position = new Vector3(-330.309998f, 2.4000001f, -43.6100006f);
        Lvl11.SetActive(true);
        Lvl22.SetActive(false);
        Lvl33.SetActive(false);
        Lvl44.SetActive(false);
        Lvl55.SetActive(false);
    }
    
    public void Lvl2()
    {
        Player.transform.position = new Vector3(-1087.30005f, 30.3099995f, -8.90999985f);
        Lvl11.SetActive(false);
        Lvl22.SetActive(true);
        Lvl33.SetActive(false);
        Lvl44.SetActive(false);
        Lvl55.SetActive(false);
    }
    
    public void Lvl3()
    {
        Player.transform.position = new Vector3(-1722.87f, 14.2600002f, 94.1999969f);
        Lvl11.SetActive(false);
        Lvl22.SetActive(false);
        Lvl33.SetActive(true);
        Lvl44.SetActive(false);
        Lvl55.SetActive(false);
    }
    
    public void Lvl4()
    {
        Player.transform.position = new Vector3(-2235.1499f, 3.22000003f, 50.7000008f);
        Lvl11.SetActive(false);
        Lvl22.SetActive(false);
        Lvl33.SetActive(false);
        Lvl44.SetActive(true);
        Lvl55.SetActive(false);
    }
    
    public void Lvl5()
    {
        Player.transform.position = new Vector3(-2979f, 4.46999979f, 50.7000008f);
        Lvl11.SetActive(false);
        Lvl22.SetActive(false);
        Lvl33.SetActive(false);
        Lvl44.SetActive(false);
        Lvl55.SetActive(true);
    }
}