using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [SerializeField] private GameObject _room;
    [SerializeField] private LineRenderer _line;
    private Vector3 _zero;
    private Vector3 _cornercorrdinate;
    private int _swhitch,_previousswhitch;
    private int _countrooms=0;
    private bool cornerfound = false;
    Stack<Vector3> Map = new Stack<Vector3>();

    void Start()
    {
      _zero.Set(0f,0f,0f);
      Generatebranch(5);
    }

    private void GenerateMap()
    {

    }

    private void Generatebranch(int count)
    {
        _countrooms=0;
        Map.Push(_zero);
        Instantiate(_room,_zero, Quaternion.identity);
        _line.positionCount++;
        _line.SetPosition(0,_zero);

        while(_countrooms<count-1)
        {
            Determinant();
        }
        _countrooms=0;
        _zero = _cornercorrdinate;
        while(_countrooms<count+1)
        {
            Determinant();
        }
    }

    private void Determinant()
    {

        _swhitch = Random.Range(1,5);
        //Debug.Log((Sides)_swhitch);
        switch (_swhitch)
        {
            case 1:
                _zero.x +=2f;
                if(Map.Contains(_zero))
                {
                    _zero = Map.Peek(); 
                    Determinant();
                }
                else 
                {
                    if(!cornerfound)
                    {
                        if (_countrooms != 0)
                        {
                            if(_previousswhitch!=_swhitch)
                            {
                                    _cornercorrdinate = Map.Peek();
                                    Debug.Log(_cornercorrdinate);
                                    cornerfound = true;
                            }
                        }
                    }
                    Map.Push(_zero);
                    DrawRoom(_zero);
                    Debug.Log((Sides)_swhitch);
                    _previousswhitch = _swhitch;
                    _countrooms++;
                    break;
                }
                break;
            case 2:
                _zero.y +=2f;
                if(Map.Contains(_zero))
                {
                    _zero = Map.Peek(); 
                    Determinant();
                }
                else 
                {
                     if(!cornerfound)
                    {
                        if (_countrooms != 0)
                        {
                            if(_previousswhitch!=_swhitch)
                            {
                                    _cornercorrdinate = Map.Peek();
                                    Debug.Log(_cornercorrdinate);
                                    cornerfound = true;
                            }
                        }
                    }
                    Map.Push(_zero);
                    DrawRoom(_zero);
                    Debug.Log((Sides)_swhitch);
                    _previousswhitch = _swhitch;
                    _countrooms++;
                    break;
                }
                break;
            case 3:
                _zero.x -=2f;
                if(Map.Contains(_zero))
                {
                    _zero = Map.Peek(); 
                    Determinant();
                }
                else 
                {
                    if(!cornerfound)
                    {
                        if (_countrooms != 0)
                        {
                            if(_previousswhitch!=_swhitch)
                            {
                                    _cornercorrdinate = Map.Peek();
                                    Debug.Log(_cornercorrdinate);
                                    cornerfound = true;
                            }
                        }
                    }
                    Map.Push(_zero);
                    DrawRoom(_zero);
                    Debug.Log((Sides)_swhitch);
                    _previousswhitch = _swhitch;
                    _countrooms++;
                    break;
                }
                break;
            case 4:
                _zero.y -=2f;
                if(Map.Contains(_zero))
                {
                    _zero = Map.Peek(); 
                    Determinant();
                }
                else 
                {
                   if(!cornerfound)
                    {
                        if (_countrooms != 0)
                        {
                            if(_previousswhitch!=_swhitch)
                            {
                                    _cornercorrdinate = Map.Peek();
                                    Debug.Log(_cornercorrdinate);
                                    cornerfound = true;
                            }
                        }
                    }
                    Map.Push(_zero);
                    DrawRoom(_zero);
                    Debug.Log((Sides)_swhitch);
                    _previousswhitch = _swhitch;
                    _countrooms++;
                    break;
                }
                break;
                 

            } 
    }
    private void DrawRoom(Vector3 coordinate)
    {
        Instantiate(_room,coordinate, Quaternion.identity);
        _line.positionCount++;
        _line.SetPosition(_line.positionCount-1,coordinate);
    }


}

enum Sides
{
    Right=1,
    Up,
    Left,
    Down
}
