namespace AsyncDemo
{
	using UnityEngine;

	public class TestConfirm : MonoBehaviour
	{
		[SerializeField]
		public PopupConfirm Confirm;

		async public void Test()
		{
			var quit = await Confirm.Open("Quit?");
			if (quit)
			{
				Debug.Log("quit");
				Application.Quit();
			}
			else
			{
				Debug.Log("cancel");
			}
		}
	}
}
