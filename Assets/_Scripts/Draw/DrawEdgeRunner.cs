using UnityEngine;

public class DrawEdgeRunner : MonoBehaviour
{

    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    int cantDrawOverLayerIndex;

    [Space(30f)]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    EdgeRunner currentLine;

    Camera cam;


    void Start()
    {
        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
    }

    void Update()
    {
        if (DrawOnOff.instance.canDraw)
        {
            if (Input.GetMouseButtonDown(0))
                BeginDraw();

            if (currentLine != null)
                Draw();

            if (Input.GetMouseButtonUp(0))
                EndDraw();
        }
    }

    // Begin Draw ----------------------------------------------
    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<EdgeRunner>();

        //Set line properties
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);

    }
    // Draw ----------------------------------------------------
    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        currentLine.AddPoint(mousePosition);
    }
    // End Draw ------------------------------------------------
    void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount < 2)
            {
                //If line has one point
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine = null;
            }
        }
    }
}