using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScratchModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _scratchMaterial = gameObject.GetComponent<SpriteRenderer>().material;
        var main = _scratchMaterial.GetTexture("_MainTex");
        _userMask = new Texture2D(main.width, main.height);
        gameObject.GetComponent<SpriteRenderer>().material.SetTexture("_DrawMask", _userMask);
        _textureSize = new Vector2(main.width, main.height);
        _objectScale = gameObject.transform.lossyScale;
        _objectSize = gameObject.GetComponent<BoxCollider2D>().size;

        if (_brush != null)
        {
            _drawSize = new Vector2(_brush.width, _brush.height);
            _drawColors = _brush.GetPixels();
        }
        else
        {
            _drawColors = Enumerable.Repeat<Color>(Color.black, (int)(_drawSize.x * _drawSize.y)).ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.IsInitialized && InputController.Instance.PrimaryDown)
        {
            if (InputController.Instance.PrimaryPoint != _lastPosition)
            {
                RaycastHit2D hit = Physics2D.Raycast(DataController.Instance.MainCamera.ScreenToWorldPoint(InputController.Instance.PrimaryPointV3), Vector2.zero);
                //RaycastHit hit;
                //if (Physics.Raycast(DataController.Instance.MainCamera.ScreenPointToRay(InputController.Instance.PrimaryPointV3), out hit))
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    //var texturePos = hit.textureCoord;
                    //var texturePos = hit.point;
                    var texturePos = new Vector3(_objectSize.x / 2f * _objectScale.x, _objectSize.y / 2f * _objectScale.y, 0) - (gameObject.transform.position - (Vector3)hit.point);
                    texturePos = new Vector3((texturePos.x / (_objectSize.x * _objectScale.x) * _textureSize.x), (texturePos.y / (_objectSize.y * _objectScale.y) * _textureSize.y), 0) - new Vector3(_drawSize.x / 2f, _drawSize.y / 2f);
                    texturePos = new Vector2(Mathf.Max(texturePos.x, 0), Mathf.Max(texturePos.y, 0));
                    _userMask.SetPixels((int)texturePos.x, (int)texturePos.y, (int)_drawSize.x, (int)_drawSize.y, _drawColors);
                    _userMask.Apply();
                }
            }

            _lastPosition = InputController.Instance.PrimaryPoint;
        }
    }

    #region Fields

    //[SerializeField]
    private Material _scratchMaterial;

    private Texture2D _userMask;

    private Color[] _drawColors;
    
    [SerializeField, Tooltip("Size of the brush if brush texture is not set")]
    private Vector2 _drawSize = new Vector2(100, 100);

    private Vector2 _lastPosition;

    private Vector2 _objectScale;
    private Vector2 _objectSize;
    private Vector2 _textureSize;

    [SerializeField, Tooltip("Brush texture for swiping")]
    private Texture2D _brush;

    #endregion

    #region Properties

    #endregion
}
