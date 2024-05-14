using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject circlePrefab; // Префаб круга
    public RectTransform tigerPrefabUp;
    public RectTransform tigerPrefabDown;
    private Vector2 initialPoint; // Изначальная точка
    private GameObject activeCircle; // Активный круг

    float direction = 0;

    private GameManager gameManager;

    private bool spellOneWayActive = false;

    public bool SpellOneWayActive { get => spellOneWayActive; set => spellOneWayActive = value; }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (direction > 0)
        {
            if (!SpellOneWayActive)
            {
                if (tigerPrefabUp.anchoredPosition.x < 400)
                {
                    tigerPrefabUp.transform.Translate(Vector3.right * (gameManager.TigerSpeed * Time.deltaTime));
                }
            }
            else
            {
                if (tigerPrefabUp.anchoredPosition.x > -400)
                {
                    tigerPrefabUp.transform.Translate(Vector3.left * (gameManager.TigerSpeed * Time.deltaTime));
                }
            }

            if (tigerPrefabDown.anchoredPosition.x > -400)
            {
                tigerPrefabDown.transform.Translate(Vector3.left * (gameManager.TigerSpeed * Time.deltaTime));
            }
            


            
        }
        else if (direction < 0)
        {
            if (!SpellOneWayActive)
            {
                if (tigerPrefabUp.anchoredPosition.x > -400)
                {
                    tigerPrefabUp.transform.Translate(Vector3.left * (gameManager.TigerSpeed * Time.deltaTime));
                }
            }
            else
            {
                if (tigerPrefabUp.anchoredPosition.x < 400)
                {
                    tigerPrefabUp.transform.Translate(Vector3.right * (gameManager.TigerSpeed * Time.deltaTime));
                }
            }

            if (tigerPrefabDown.anchoredPosition.x < 400)
            {
                tigerPrefabDown.transform.Translate(Vector3.right * (gameManager.TigerSpeed * Time.deltaTime));
            }
            
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        activeCircle = Instantiate(circlePrefab, eventData.position, Quaternion.identity, transform);
        initialPoint = eventData.position;


    }
            
    public void OnDrag(PointerEventData eventData)
    {


        if (activeCircle != null)
        {
            activeCircle.transform.position = eventData.position;
            direction = eventData.position.x - initialPoint.x;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = 0;
        Destroy(activeCircle);
        activeCircle = null;

    }
}
