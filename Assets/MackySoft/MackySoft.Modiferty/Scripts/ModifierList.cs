using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MackySoft.Modiferty {

	public interface IReadOnlyModifierList<T> : IReadOnlyList<IModifier<T>>, IEvaluatable<T,T> {
	}

	public interface IModifierList<T> : IList<IModifier<T>>, IReadOnlyModifierList<T> {
		new int Count { get; }
	}

	[Serializable]
	public class ModifierList<T> : Collection<IModifier<T>>, IModifierList<T> {
		
		public T Evaluate (T value) {
			if (Items.Count > 0) {
				foreach (IModifier<T> modifier in Items.OrderByDescending(m => m.Priority)) {
					value = modifier.Evaluate(value);
				}
			}
			return value;
		}

	}

}