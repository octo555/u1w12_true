using UnityEngine;
using System.Collections.Generic;

public class EdgeRunner : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> points = new List<Vector2>();
    public int pointsCount = 0;

    //The minimum distance between line's points.
    float pointsMinDistance = 0.1f;

    public void AddPoint(Vector2 newPoint)
    {
        //If distance between last point and new point is less than pointsMinDistance do nothing (return)
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
            edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

}