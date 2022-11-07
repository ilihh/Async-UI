namespace AsyncDemo
{
	using System;

	public class Awaiter
	{
		IAwaitable awaitable;

		Action continuation;

		public bool IsCompleted
		{
			get;
			private set;
		}

		public Awaiter(IAwaitable awaitable)
		{
			this.awaitable = awaitable;

			this.awaitable.OnComplete += () =>
			{
				IsCompleted = true;
				continuation?.Invoke();
			};
		}

		public void OnCompleted(Action continuation)
		{
			if (IsCompleted)
			{
				continuation();
				return;
			}

			this.continuation = continuation;
		}

		public void GetResult()
		{
		}
	}
}