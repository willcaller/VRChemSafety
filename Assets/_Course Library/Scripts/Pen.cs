using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Pen : MonoBehaviour
{

    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;


    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private ClipBoard _clipBoard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchLastFrame;
    private Quaternion _lastTouchRot;




    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Draw();

    }

    private void Draw()
    {
        if (Physics.Raycast(_tip.position, direction: transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("ClipBoard"))
            {
                if (_clipBoard == null)
                {
                    _clipBoard = _touch.transform.GetComponent<ClipBoard>();

                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _clipBoard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _clipBoard.textureSize.y - (_penSize / 2));

                if ((y < 0 || y > _clipBoard.textureSize.y) || (x < 0 || x > _clipBoard.textureSize.x)) return;


                if (_touchLastFrame)
                {
                    _clipBoard.texture.SetPixels(x, y, blockWidth: _penSize, blockHeight: _penSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(a: _lastTouchPos.x, b: x, t: f);
                        var lerpY = (int)Mathf.Lerp(a: _lastTouchPos.y, b: y, t: f);
                        _clipBoard.texture.SetPixels(lerpX, lerpY, blockWidth: _penSize, blockHeight: _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;

                    _clipBoard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchLastFrame = true;
                return;

            }

        }

        _clipBoard = null;
        _touchLastFrame = false;
    }
}
