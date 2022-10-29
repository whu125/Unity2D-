using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DefeatMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMainMap()
    {
        switch (GameManager.guankapanding)
        {
            case 1: SceneManager.LoadScene(2); break;
            case 2: SceneManager.LoadScene(2); break;
            case 3: SceneManager.LoadScene(5); break;
            case 4: SceneManager.LoadScene(5); break;
            case 5: SceneManager.LoadScene(8); break;
            case 6: SceneManager.LoadScene(8); break;
            case 7: SceneManager.LoadScene(8); break;
                //   case 8: SceneManager.LoadScene(8); break;
                // case 9: SceneManager.LoadScene(8); break;

        }
    }
}
