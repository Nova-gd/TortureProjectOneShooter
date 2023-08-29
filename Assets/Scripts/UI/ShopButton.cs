using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public void LoadShopLevel()
    {
        SceneManager.LoadScene("ShopScreen");
    }
}
