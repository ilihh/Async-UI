namespace AsyncDemo
{
	using System;

	public interface IAwaitable
	{
		event Action OnComplete;
	}
}