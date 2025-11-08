using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emergency : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;

    private void Awake()
    {
        AllOff();
    }

    //private void Start()
    //{
    //    one.SetActive(true);
    //}

    public void OneOff()
    {
        one.SetActive(false);
    }
    public void TwoOff()
    {
        two.SetActive(false);
    }
    public void ThreeOff()
    {
        three.SetActive(false);
    }
    public void FourOff()
    {
        four.SetActive(false);
    }
    public void FiveOff()
    {
        five.SetActive(false);
    }
    public void SixOff()
    {
        six.SetActive(false);
    }
    public void SevenOff()
    {
        seven.SetActive(false);
    }



    public void OneOn()
    {
      Debug.Log("OneOn called");
        one.SetActive(true);
        Debug.Log("one active: " + one.activeSelf)  ;
    }


    public void TwoOn()
    {
        Debug.Log("TwoOn called");
        two.SetActive(true);
        Debug.Log("two active: " + two.activeSelf);
    }

    public void ThreeOn()
    {
        Debug.Log("ThreeOn called");
        three.SetActive(true);
        Debug.Log("three active: " + three.activeSelf);
    }

    public void FourOn()
    {
        Debug.Log("FourOn called");
        four.SetActive(true);
        Debug.Log("four active: " + four.activeSelf);
    }

    public void FiveOn()
    {
        Debug.Log("FiveOn called");
        five.SetActive(true);
        Debug.Log("five active: " + five.activeSelf);
    }

    public void SixOn()
    {
        Debug.Log("SixOn called");
        six.SetActive(true);
        Debug.Log("six active: " + six.activeSelf);
    }

    public void SevenOn()
    {
        Debug.Log("SevenOn called");
        seven.SetActive(true);
        Debug.Log("seven active: " + seven.activeSelf);
    }

    public void AllOff()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        six.SetActive(false);
        seven.SetActive(false);
    }
}
