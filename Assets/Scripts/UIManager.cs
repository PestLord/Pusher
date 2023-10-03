using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Manager _gameManager;
    [SerializeField] private MenuElement _menuItem;
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _cylinderImage;
    [SerializeField] private Transform _parent;
    [SerializeField] private Color[] _colors;
    private int _count;
    private Dictionary<Color, MenuElement> _items;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _colors.Length; i++)
        {
            var item = Instantiate(_menuItem, _parent);
            item.GetComponent<Transform>().position += new Vector3(i * 100, 0);
            var image = item.GetComponentInChildren<Image>();
            image.material.color = _colors[i];
            item.Count++;
            _items[_colors[i]] = item;
        }
    }
    
    public void SetEnemiesCount(Color color)
    {
        _items[color].Count--;
        _items[color].GetComponent<TextMeshPro>().text = _items[color].Count.ToString();
    }

    public void SetEnemiesSpawned(Color color)
    {
        _items[color].Count++;
        _items[color].GetComponent<TextMeshPro>().text = _items[color].Count.ToString();
    }
    
}
