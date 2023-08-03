using UnityEngine;

public class PlayerInteract : MonoBehaviour
{   
    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;

    private Camera _camera;
    private PlayerUI _playerUI;
    private InputManger _inputManger;

    private void Start()
    {
        _camera = GetComponent<PlayerLook>().Camera;
        _playerUI = GetComponent<PlayerUI>();
        _inputManger = GetComponent<InputManger>();
    }

    private void Update()
    {
        _playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, _distance, _mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>()!=null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(interactable.PromptMessage);

                if (_inputManger.OnFoot.Interact.triggered)
                {                    
                    interactable.BaseInteract();
                }
            }
        }
    }
}
