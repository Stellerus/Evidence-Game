using System.Collections.Generic;
using UnityEngine;

public class FolderButton2D : MonoBehaviour
{
    [Header("Sheets cases")]
    public List<GameObject> sheetPrefabs;

    [Header("Sheet settings")]
    public Transform stackAnchor;
    public float sheetOffset = 0.15f;

    private bool isOpened = false;

    private void OnMouseDown()
    {
        if (isOpened) return;
        isOpened = true;

        for (int i = 0; i < sheetPrefabs.Count; i++)
        {
            Vector3 localOffset = new Vector3(0, -i * sheetOffset, 0);

            GameObject prefab = sheetPrefabs[i];
            GameObject newSheet = Instantiate(prefab, stackAnchor.position + localOffset, Quaternion.identity);

            DragAndDropTable dd = newSheet.GetComponent<DragAndDropTable>();
            if (dd != null)
            {
                dd.originStack = stackAnchor;
                dd.originLocalOffset = localOffset; 
            }
        }
    }
}
