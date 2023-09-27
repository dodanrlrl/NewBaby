using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool Instance
    {
        get
        {
            if (null == _instance)
            {
                return null;
            }
            return _instance;
        }
    }
    public GameObject BaseBullet;
    private Queue<Bullet> _poolingObjQueue = new Queue<Bullet>();


    private void Awake()
    {
        if (null == _instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Init(3);
    }

    private Bullet CreateObj()
    {
        Bullet bullet = Instantiate(BaseBullet, transform).GetComponent<Bullet>();
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public void Init(int count)
    {
        for(int i = 0; i < count; i++) 
        {
            _poolingObjQueue.Enqueue(CreateObj());
        }
    }

    public Bullet GetObject()
    {
        if(Instance._poolingObjQueue.Count>0)
        {
            Bullet obj = Instance._poolingObjQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Bullet newObj = Instance.CreateObj();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);

            return newObj;
        }
    }

    public void ReturnObj(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector2.zero;
        bullet.transform.SetParent(Instance.transform);

        Instance._poolingObjQueue.Enqueue(bullet);

    }


}
