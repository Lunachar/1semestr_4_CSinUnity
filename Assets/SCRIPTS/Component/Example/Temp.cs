using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    struct User
    {
        public string name;
        public int health;
        public int id;
    }


    public delegate int TestDelegate(int val1, int val2);

    public TestDelegate summ;
    public TestDelegate substraction;
    public TestDelegate divide;
    public TestDelegate multiply;


    static int SomeMethod1(int a, int b)
    {
        Debug.Log("summ: " + (a + b));
        return a + b;
    }

    static int SomeMethod2(int a, int b)
    {
        Debug.Log("substract: " + (a - b));
        return a - b;
    }
    static int SomeMethod3(int a, int b)
    {
        Debug.Log("divide: " + (a / b));
        return a/b;
    }
    static int SomeMethod4(int a, int b)
    {
        Debug.Log("multiply: " + (a * b));
        return a*b;
    }




    void Start()
    {
        User user = new User();
        user.name = "Test";
        user.health = 100;
        Debug.Log(user.name);


        summ = SomeMethod1;
        substraction = SomeMethod2;
        divide = SomeMethod3;
        multiply = SomeMethod4;

        divide += SomeMethod1;
        divide += SomeMethod2;
        divide += SomeMethod3;
        divide += SomeMethod4;


    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            int temp = divide.Invoke(100, 50);
            Debug.Log(temp);

        }

        
    }
}
