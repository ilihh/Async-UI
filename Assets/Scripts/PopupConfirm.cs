namespace AsyncDemo
{
	using System;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.EventSystems;

	public class PopupConfirm : MonoBehaviour, IAwaitable<bool>
	{
		[SerializeField]
		protected TextMeshProUGUI Message;

		[SerializeField]
		protected Button ButtonOk;

		[SerializeField]
		protected Button ButtonCancel;

		event Action<bool> onComplete;

		public event Action<bool> OnComplete
		{
			add => onComplete += value;
			remove => onComplete -= value;
		}

		protected virtual void Start() => AddListeners();

		protected virtual void OnDestroy()
		{
			RemoveListeners();
			// notify of the cancellation upon deletion
			Cancel();
		}

		void AddListeners()
		{
			ButtonOk.onClick.AddListener(Confirm);
			ButtonCancel.onClick.AddListener(Cancel);
		}

		void RemoveListeners()
		{
			ButtonOk.onClick.RemoveListener(Confirm);
			ButtonCancel.onClick.RemoveListener(Cancel);
		}

		public void Confirm() => Complete(true);

		public void Cancel() => Complete(false);

		void Complete(bool result)
		{
			gameObject.SetActive(false);

			// notify the result
			onComplete?.Invoke(result);
		}

		public PopupConfirm Open(string message = null)
		{
			Message.text = message;
			gameObject.SetActive(true);
			EventSystem.current.SetSelectedGameObject(ButtonOk.gameObject);

			// return the same object so that we can immediately use await
			return this;
		}

		public Awaiter<bool> GetAwaiter() => new Awaiter<bool>(this);
	}
}