using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MG_PhysicsDraw2D
{
    public class PD2_DrawingManager : MonoBehaviour
    {
        public LayerMask ignoreLayer;
        public LayerMask objectLayer;
        float distanceMovedThreshold = 0.05f; // ê›íËÇ∑ÇÈêîílÅió·: 10Åj
        Vector3 lastMousePosition;

        static PD2_DrawingManager _instance;
        public static PD2_DrawingManager Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType<PD2_DrawingManager>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        [HideInInspector] public PD2_EventManager eventManager = new PD2_EventManager();
        [HideInInspector] public PD2_Pointer pointer;
        [HideInInspector] public Transform Transform { get; set; }
        [HideInInspector] public List<PD2_Drawing> drawingList = new List<PD2_Drawing>();
        [HideInInspector] public List<PD2_FreezableElement> freezableElementList = new List<PD2_FreezableElement>();
         public PD2_Drawing currentDrawing;
        [HideInInspector] public float totalLength = 0;

        [Header("Scene Settings")]
        public float minPointsDistance = 0.01f;
        public bool freezeWhileDrawing = true;
        public bool enablePointerCollider = true;
        public float maxTotalLength = 0;

        [Header("Setup")]
        public PD2_Drawing drawingTemplate;
        public Transform drawingContainer;
        // v5.1 - added noStopDrawingLayers layermask to the Drawing Manager setup
        public LayerMask noStopDrawingLayers;

        Vector3 lastPointerPosition;

        bool _firstClick = true;

        public float drawInterval;
        private float drawTimer;

        void Awake()
        {
            Transform = transform;
            pointer = GetComponentInChildren<PD2_Pointer>();
            Transform.position = Vector3.zero;
            drawTimer = drawInterval;
        }

        void Update()
        {
            drawTimer += Time.deltaTime;

            eventManager.TriggerEvent(PD2Event.OnUpdate);

            float distanceMoved = Vector3.Distance(Input.mousePosition, lastMousePosition);


            if (drawTimer > drawInterval)
            {
                if (Input.GetMouseButtonDown(0) && !currentDrawing && distanceMoved >= distanceMovedThreshold)
                {
                    OnPointerDown();
                    eventManager.TriggerEvent(PD2Event.OnPointerDown);
                    
                }

                if (Input.GetMouseButton(0))
                {
                    OnPointer();
                    eventManager.TriggerEvent(PD2Event.OnPointer);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    OnPointerUp();
                    eventManager.TriggerEvent(PD2Event.OnPointerUp);
                    drawTimer = 0;
                }

            }

        }

        public void OnPointerDown()
        {
            if (maxTotalLength == 0 || totalLength < maxTotalLength)
            {
                // v5.1.1 - bugfix: fixed pointer position getting stuck on colliders in mobile builds
                pointer.BringPointerToTouchPoint();

                if (enablePointerCollider)
                    pointer.circleCollider.isTrigger = false;

                if (freezeWhileDrawing)
                {
                    foreach (PD2_FreezableElement element in freezableElementList)
                    {
                        element.Freeze();
                    }
                }

                currentDrawing = PD2_Drawing.StartDrawing(pointer.Position);

                float pointerScale = currentDrawing.lineRenderer.widthCurve.Evaluate(1) * currentDrawing.lineRenderer.widthMultiplier;
                pointer.transform.localScale = new Vector3(pointerScale + 0.1f, pointerScale + 0.1f, 1);

                lastPointerPosition = pointer.Position;
            }
        }
        public void OnPointer()
        {
            if (currentDrawing && Vector3.Distance(pointer.Position, lastPointerPosition) >= minPointsDistance)
            {
                float tempCurrentLength = (currentDrawing.length +
                            Vector3.Distance(pointer.Position, lastPointerPosition));
                float tempLength = tempCurrentLength + totalLength;

                if (maxTotalLength > 0 && tempLength >= maxTotalLength)
                {
                    Vector3 vp1 = currentDrawing.lineRenderer.GetPosition(currentDrawing.lineRenderer.positionCount - 1);
                    Vector3 vp2 = pointer.Position - currentDrawing.startPosition;
                    for (float t = 0; t <= 1; t += 0.1f)
                    {
                        Vector3 point = Vector3.Lerp(vp1, vp2, t);
                        float tempLength2 = currentDrawing.length + totalLength + Vector3.Distance(vp1, point);
                        if (tempLength2 >= maxTotalLength)
                        {
                            currentDrawing.AddPoint(point + currentDrawing.startPosition);
                            OnPointerUp();
                            return;
                        }
                    }
                }

                if (currentDrawing.maxLength > 0 && tempCurrentLength >= currentDrawing.maxLength)
                {
                    Vector3 vp1 = currentDrawing.lineRenderer.GetPosition(currentDrawing.lineRenderer.positionCount - 1);
                    Vector3 vp2 = pointer.Position - currentDrawing.startPosition;
                    for (float t = 0; t <= 1; t += 0.1f)
                    {
                        Vector3 point = Vector3.Lerp(vp1, vp2, t);
                        float tempLength2 = currentDrawing.length + Vector3.Distance(vp1, point);
                        if (tempLength2 >= currentDrawing.maxLength)
                        {
                            currentDrawing.AddPoint(point + currentDrawing.startPosition);
                            OnPointerUp();
                            return;
                        }
                    }
                }

                currentDrawing.AddPoint(pointer.Position);

                lastPointerPosition = pointer.Position;
            }
        }
        public void OnPointerUp()
        {
            if (currentDrawing)
            {
                if (currentDrawing.pointsCount > 2)
                {
                    currentDrawing.FinishDrawing();
                }
                else if (currentDrawing)
                {
                    Destroy(currentDrawing.gameObject);
                }

                if (freezeWhileDrawing || _firstClick)
                {
                    foreach (PD2_FreezableElement element in freezableElementList)
                    {
                        element.Unfreeze();
                    }
                }

                totalLength += currentDrawing.length;

                if (StopTime.instance.isPaused)
                {
                    currentDrawing.GetComponent<Rigidbody2D>().isKinematic = true;
                    currentDrawing.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }

                if (currentDrawing.GetComponent<EraseTime>())
                {
                    currentDrawing.GetComponent<EraseTime>().enabled = true;
                }

                if (currentDrawing.GetComponent<CharactorMove>())
                {
                    currentDrawing.GetComponent<CharactorMove>().enabled = true;
                }

                currentDrawing.gameObject.layer = objectLayer;

                currentDrawing = null;
            }

            if (enablePointerCollider)
                pointer.circleCollider.isTrigger = true;

            _firstClick = false;
        }

        public void AddDrawing(PD2_Drawing drawing)
        {
            if (!drawingList.Contains(drawing))
            {
                drawingList.Add(drawing);
            }
        }
        public void RemoveDrawing(PD2_Drawing drawing)
        {
            if (drawingList.Contains(drawing))
            {
                drawingList.Remove(drawing);
                Destroy(drawing.gameObject);
            }
        }
        public void RemoveDrawing(int index)
        {
            if (drawingList.Count > index)
            {
                PD2_Drawing drawing = drawingList[index];
                drawingList.RemoveAt(index);
                Destroy(drawing.gameObject);
            }
        }

        public void RemoveDrawingAll()
        {
            for (int i = drawingList.Count - 1; i >= 0; i--)
            {
                Destroy(drawingList[i].gameObject);
            }
        }
    }
}