using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    // Массив объектов, которые будут включаться/выключаться
    public GameObject[] objectsToToggle;
    public GameObject ParentObjectToToggle;

    // Этот метод вызывается, когда пользователь кликает мышью по Collider'у этого GameObject'а
    void OnMouseDown()
    {
        // Включаем каждый объект из массива
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null) // Проверяем, что объект назначен в массиве
            {
                obj.SetActive(true); // Делаем объект активным
            }
        }
    }

    // Метод Update вызывается каждый кадр
    void Update()
    {
        // Проверяем, нажата ли клавиша Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Выключаем каждый объект из массива
            foreach (GameObject obj in objectsToToggle)
            {
                if (obj != null) // Проверяем, что объект назначен в массиве
                {
                    obj.SetActive(false); // Делаем объект неактивным
                }
            }
        }
    }
}
