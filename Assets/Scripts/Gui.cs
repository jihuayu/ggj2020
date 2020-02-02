using UnityEngine;

namespace DefaultNamespace
{
    public class Gui  : MonoBehaviour 
    {
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(1000,100,300,200));
            var s1 = GameObject.FindGameObjectsWithTag("virus").Length;
            var s2 = GameObject.FindGameObjectsWithTag("anti").Length;
            GUILayout.TextField("剩余" + s1 + "病毒");
            GUILayout.TextField("剩余" + s2 + "抗体");
            GUILayout.EndArea();
        }
    }
}