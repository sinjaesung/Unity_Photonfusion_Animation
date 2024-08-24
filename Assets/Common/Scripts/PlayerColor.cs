using Fusion;
using UnityEngine;

namespace Animations
{
	public class PlayerColor : NetworkBehaviour
	{
		// PRIVATE MEMBERS

		[SerializeField]
		private Color _inputAuthorityColor = Color.white;
		[SerializeField]
		private Color _proxyColor = Color.gray;
		[SerializeField]
		private Color _stateAuthorityColor = Color.blue;

		// NetworkBehaviour INTERFACE

		public override void Spawned()
		{
			var renderer = GetComponentInChildren<SkinnedMeshRenderer>();
			renderer.material.color = GetColor();
		}

		// PRIVATE METHODS

		private Color GetColor()
		{
			if (IsProxy == true)
				return _proxyColor;

			return HasInputAuthority == true ? _inputAuthorityColor : _stateAuthorityColor;
		}
	}
}
