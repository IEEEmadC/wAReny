using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
   // public GameController _GameController;
	public void MaleSelect()
    {
      //  _GameController.Gender = "Male";
        Application.LoadLevel("Test");
    }
    public void FemaleSelect()
    {
      //  _GameController.Gender = "Female";
        Application.LoadLevel("Test");
    }

    public void Load(string level)
    {
        Application.LoadLevel(level);
    }
}
