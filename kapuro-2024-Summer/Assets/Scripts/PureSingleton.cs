using System;
using System.Dynamic;

public abstract class PureSingleton<T> : IDisposable where T : class, new()
{
    private static T instance = null;

    //Instance�̃V���^�b�N�X�V���K�[(���ߍ\��) �v����ɁA�V���v���ł킩��₷�����������邱��
    //I����ăC���X�^���X���擾���邱�Ƃ��ł���
    public static T I => Instance;
    public static T Instance
    {
        get
        {
            createInstance();
            return instance;
        }
    }

    //�C���X�^���X�𐶐�����
    public static void createInstance()
    {
        if(instance == null)
        {
            instance = new T();
        }
    }

    //Singleton�����݂��邩
    public static bool isExists()
    {
        return instance != null;
    }

    //Singleton��j������
    public virtual void Dispose()
    {
        instance = null;
    }
}

/* reference -> https://qiita.com/Cova8bitdot/items/29b7064c7472a6f34972 */

/*
 * T�ɃN���X�������Čp������
 */