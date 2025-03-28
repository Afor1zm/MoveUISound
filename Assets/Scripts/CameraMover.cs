using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraMover : MonoBehaviour
{
   [SerializeField] private Button _moveUp;
   [SerializeField] private Button _moveLeft;
   [SerializeField] private Button _moveRight;
   [SerializeField] private Button _moveDown;
   [SerializeField] private EventSystem _eventSystem;

   private void Awake()
   {
      _moveUp.onClick.AddListener(delegate { transform.position += Vector3.forward; });
      _moveLeft.onClick.AddListener(delegate { transform.position += Vector3.left; });
      _moveRight.onClick.AddListener(delegate { transform.position += Vector3.right; });
      _moveDown.onClick.AddListener(delegate { transform.position += Vector3.back; });
   }

   private void OnDisable()
   {
       _moveUp.onClick.RemoveListener(delegate { transform.position += Vector3.forward; });
       _moveLeft.onClick.RemoveListener(delegate { transform.position += Vector3.left; });
       _moveRight.onClick.RemoveListener(delegate { transform.position += Vector3.right; });
       _moveDown.onClick.RemoveListener(delegate { transform.position += Vector3.back; });
   }
}