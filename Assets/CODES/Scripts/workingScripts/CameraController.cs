using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnnamedGame.Camera
{
	public class CameraController : MonoBehaviour
	{
		/// <summary>
		/// The speed/smoothing of the camera following the mouse.
		/// </summary>
		[Tooltip("The speed/smoothing of the camera following the mouse.")]
		public float MouseFollowSpeed = 10.0f;
		
		/// <summary>
		/// The speed/smoothing of the camera following the player.
		/// </summary>
		[Tooltip("The speed/smoothing of the camera following the player.")]
		public float PlayerFollowSpeed = 0.07f;

		/// <summary>
		/// The target of this camera. Good to change this for cut scenes and etc.
		/// </summary>
		[Tooltip("The target of this camera. Good to change this for cut scenes and etc.")]
		public GameObject CameraTarget;
		
		/// <summary>
		/// The camera that this is controlling.
		/// </summary>
		[Tooltip("The camera that this is controlling.")]
		public GameObject Camera;
		
		/// <summary>
		/// The maximum on the x and y axis the camera can move. ( Relative to its child posistion of the camera parent. )
		/// </summary>
		[Tooltip("The maximum on the x and y axis the camera can move. ( Relative to its child posistion of the camera parent. )")]
		public Vector2 MaxClamps;
		
		/// <summary>
		/// The Minimum on the x and y axis the camera can move. ( Relative to its child posistion of the camera parent. )
		/// </summary>
		[Tooltip("The Minimum on the x and y axis the camera can move. ( Relative to its child posistion of the camera parent. )")]
		public Vector2 MinClamps;
		
		/// <summary>
		/// The maximum on the x and y axis the camera can move while the player is moving. ( Relative to its child posistion of the camera parent. )
		/// </summary>
		[Tooltip("The maximum on the x and y axis the camera can move while the player is moving. ( Relative to its child posistion of the camera parent. )")]
		public Vector2 MaxClampsWhileMoving;
		
		/// <summary>
		/// The Minimum on the x and y axis the camera can move while the player is moving. ( Relative to its child posistion of the camera parent. )
		/// </summary>
		[Tooltip("The Minimum on the x and y axis the camera can move while the player is moving. ( Relative to its child posistion of the camera parent. )")]
		public Vector2 MinClampsWhileMoving;

		/// <summary>
		/// The name of the horizontal movement axis.
		/// </summary>
		[Tooltip("The name of the horizontal movement axis.")]
		public string MovementXAxis = "Horizontal";
	
		/// <summary>
		/// The name of the vertical movement axis.
		/// </summary>
		[Tooltip("The name of the vertical movement axis.")]
		public string MovementYAxis = "Vertical";
		
		/// <summary>
		/// The camera component of the camera that is being controlled.
		/// </summary>
		private UnityEngine.Camera _camera;
		
		/// <summary>
		/// The parent object of the camera that controls the local space for the camera.
		/// </summary>
		private Transform _cameraParent;
		
		/// <summary>
		/// The transform of the camera that is being controlled.
		/// </summary>
		private Transform _cameraTransform;
		
		/// <summary>
		/// The boarder sizes of where the mouse needs to be to move the camera in that direction.
		/// </summary>
		private Vector2 _cameraMovementBorderSizes;
		
		/// <summary>
		/// The current maximum clamps.
		/// </summary>
		private Vector2 _maxClamps;
		
		/// <summary>
		/// The current minimum clamps.
		/// </summary>
		private Vector2 _minClamps;

		private void Awake()
		{
			//Sets up inital variables with the public variables that are available.
			_camera = Camera.GetComponent<UnityEngine.Camera>();
			_cameraTransform = Camera.transform;
			_cameraParent = _cameraTransform.parent;
			SetupBorderSizes();
			_maxClamps = MaxClamps;
			_minClamps = MinClamps;
		}
		
		/// <summary>
		/// Automatically sets up the boarder sizes to scale somewhat well with any resoltuion.
		/// </summary>
		private void SetupBorderSizes()
		{
			float widthAmount = Screen.width / 3.0f;
			float heightAmount = Screen.height / 3.0f;
			_cameraMovementBorderSizes.x = widthAmount;
			_cameraMovementBorderSizes.y = heightAmount;
		}

		private void Update()
		{
			
			// change these to inputs for movement, this sets the clamps based on if the player is moving or not
			if (Input.GetAxisRaw(MovementXAxis) != 0.0f || Input.GetAxisRaw(MovementYAxis) != 0.0f)
			{
				_maxClamps.x = MaxClampsWhileMoving.x;
				_maxClamps.y = MaxClampsWhileMoving.y;
				_minClamps.x = MinClampsWhileMoving.x;
				_minClamps.y = MinClampsWhileMoving.y;
			}
			else
			{
				_maxClamps.x = MaxClamps.x;
				_maxClamps.y = MaxClamps.y;
				_minClamps.x = MinClamps.x;
				_minClamps.y = MinClamps.y;
			}
		}

		private void FixedUpdate()
		{
			// Check if the mouse is on the edges of the screen and if so move the camera towards the mouse
			if (Input.mousePosition.x >= Screen.width - _cameraMovementBorderSizes.x && _cameraTransform.localPosition.x <= _maxClamps.x)
			{
				_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTransform.position + Vector3.right,
					MouseFollowSpeed * Time.deltaTime);
			}
			if (Input.mousePosition.x <= 0 + _cameraMovementBorderSizes.x &&  _cameraTransform.localPosition.x >= _minClamps.x)
			{
				_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTransform.position - Vector3.right,
					MouseFollowSpeed * Time.deltaTime);
			}
			if (Input.mousePosition.y >= Screen.height - _cameraMovementBorderSizes.y && _cameraTransform.localPosition.y <= _maxClamps.y)
			{
				_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTransform.position + Vector3.up,
					Time.deltaTime * MouseFollowSpeed);
			}
			if (Input.mousePosition.y <= 0 + _cameraMovementBorderSizes.y && _cameraTransform.localPosition.y >= _minClamps.y)
			{
				_cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTransform.position - Vector3.up,
					Time.deltaTime * MouseFollowSpeed);
			}
			
			//Snap the camera within the clamp parameters if out of it, and if not just keep it within those clamped parameters.
			_cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition ,new Vector3(Mathf.Clamp(_cameraTransform.localPosition.x,_minClamps.x,_maxClamps.x),Mathf.Clamp(_cameraTransform.localPosition.y,_minClamps.y,_maxClamps.y),_cameraTransform.localPosition.z),MouseFollowSpeed*Time.deltaTime);
			
			//Make the camera follow the player.
			_cameraParent.position = Vector3.Lerp(_cameraParent.position, CameraTarget.transform.position, PlayerFollowSpeed);
		}

		/// <summary>
		/// Shake the camera.
		/// </summary>
		/// <param name="duration">How long to shake it for.</param>
		/// <param name="intensity">The minimum and maximum to rotate the camera.</param>
		/// <param name="frequency">The amount ofseconds inbetween shakes.</param>
		/// <returns></returns>
		public IEnumerator Shake(float duration, float intensity, float frequency)
		{
			float timeSoFar = 0;
			while (timeSoFar < duration)
			{
				timeSoFar = timeSoFar + Time.deltaTime;
				_cameraParent.transform.localEulerAngles =  new Vector3(0, 0, UnityEngine.Random.Range(-intensity, intensity));
				yield return new WaitForSeconds(frequency);
				timeSoFar = timeSoFar + frequency;
			}
			_cameraParent.transform.localEulerAngles = Vector3.zero;
		}
	}
}