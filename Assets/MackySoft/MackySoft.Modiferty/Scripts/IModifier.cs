namespace MackySoft.Modiferty {

	public interface IEvaluatable<Ret, Arg> {
		/// <summary>
		/// Evaluate the value.
		/// </summary>
		/// <param name="value"> Value to be modified. </param>
		Ret Evaluate(Arg value);

	}

	public interface IModifier {
		/// <summary>
		/// <para> Priority of evaluation. </para>
		/// <para> See: <see cref="ModifierList{T}.Evaluate(T)"/> </para>
		/// </summary>
		int Priority { get; }
	}

	public interface IModifier<T> : IModifier, IEvaluatable<T,T> {
	}

}