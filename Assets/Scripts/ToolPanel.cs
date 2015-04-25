using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System;
using System.Windows.Forms;

using DG.Tweening;

public class ToolPanel : MonoBehaviour {

    public CanvasGroup canvasGroup;
    public CanvasGroup gridCanvasGroup;
    public Grid grid;

    [DllImport("System.Windows.Forms.dll")]
    private static extern void SaveFileDialog();
    [DllImport("System.Windows.Forms.dll")]
    private static extern void OpenFileDialog(); 

	void Update () {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    gridCanvasGroup.blocksRaycasts = !gridCanvasGroup.blocksRaycasts;
        //    canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        //    canvasGroup.alpha = canvasGroup.blocksRaycasts ? 1f : 0f;

        //    if (canvasGroup.blocksRaycasts)
        //    {
        //        transform.DOMoveY(35f + UnityEngine.Screen.height, 0.2f).From();
        //    }
        //}
	}

    public void SaveFile()
    {
        System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
        sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        sfd.FilterIndex = 1;
        sfd.RestoreDirectory = true;

        if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            File.WriteAllText(sfd.FileName, grid.GetTextContent());
        }
    }

    public void LoadFile()
    {
        System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        ofd.Title = "Open Text File";
        ofd.Filter = "TXT files|*.txt";
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            grid.LoadText(File.ReadAllText(ofd.FileName));
        }
    }
}
