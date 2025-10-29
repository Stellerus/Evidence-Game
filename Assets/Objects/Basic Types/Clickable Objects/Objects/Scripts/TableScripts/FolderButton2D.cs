using UnityEngine;

public class FolderButton2D : MonoBehaviour
{
    public GameObject sheetPrefab;
    public Transform stackAnchor;
    public int count = 5;
    public Vector3 offset = new Vector3(0, -0.5f, -0.01f);

    private bool opened = false;

    void OnMouseDown()
    {
        if (!opened) OpenFolder();
        else CloseFolder();
    }

    void OpenFolder()
    {
        for (int i = 0; i < count; i++)
        {

            Vector3 localOffset = offset * i;
            localOffset.z -= 0.05f * 1;
            Vector3 pos = stackAnchor.position + localOffset;

            GameObject go = Instantiate(sheetPrefab, pos, Quaternion.identity, stackAnchor);

            var sc = go.GetComponent<SheetController2D>();
            if (sc != null) sc.SetOrigin(stackAnchor, localOffset);

            var dd = go.GetComponent<DragAndDropTable>();
            if (dd != null)
            {
                dd.originStack = stackAnchor;
                dd.originLocalOffset = localOffset;
            }
        }
        opened = true;
    }

    void CloseFolder()
    {
        foreach (Transform t in stackAnchor) Destroy(t.gameObject);
        opened = false;
    }
}
