namespace AsyncDemo
{
	using System;
	using System.Runtime.CompilerServices;

	public class Awaiter<TResult> : INotifyCompletion
	{
		TResult result;

		Action continuation;

		public bool IsCompleted
		{
			get;
			private set;
		}

		public Awaiter(IAwaitable<TResult> awaitable)
		{
			void setResult(TResult result)
			{
				// unsubscribe after receiving the result
				awaitable.OnComplete -= setResult;

				// save the result
				IsCompleted = true;
				this.result = result;

				var c = continuation;
				// since notify only once, we can clear
				continuation = null;
				// notify of the completion
				c?.Invoke();
			}

			// subscribe to the result of the operation
			awaitable.OnComplete += setResult;
		}

		public void OnCompleted(Action continuation)
		{
			if (IsCompleted)
			{
				continuation();
				return;
			}

			// save a delegate to notify completion
			this.continuation += continuation;
		}

		public TResult GetResult()
		{
			return result;
		}
	}
}