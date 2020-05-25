using System;
using System.Collections.Generic;
using UnityEngine;


namespace MackySoft.Modiferty {

	[Serializable]
	public struct ModifiableStruct<T> : IEvaluatable<T> {

		public delegate T ModifierDelegate(T t);

		[SerializeField]
		T m_BaseValue;

		[SerializeField]
		List<ModifierDelegate> m_Modifiers;

		public T BaseValue {
			get => m_BaseValue;
			set => m_BaseValue = value;
		}

		public IList<ModifierDelegate> Modifiers => m_Modifiers;


		public ModifiableStruct(T baseValue = default, int capacity = 10) {
			m_BaseValue = baseValue;
			m_Modifiers = new List<ModifierDelegate>(capacity);
		}

		public T Evaluate() {
			T v = BaseValue;
			foreach (var f in m_Modifiers) v = f(v);
			return v;
		}
	}
}