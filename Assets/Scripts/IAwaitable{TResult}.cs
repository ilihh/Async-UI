namespace AsyncDemo
{
	using System;

	public interface IAwaitable<TResult>
	{
		event Action<TResult> OnComplete;

		public Awaiter<TResult> GetAwaiter();
	}
}