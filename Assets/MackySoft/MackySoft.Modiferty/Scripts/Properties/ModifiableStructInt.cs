using System;
using UnityEngine;

namespace MackySoft.Modiferty {

	public static partial class ModifiableStructExtention {

		public static void AddEvaluatable<T, E>(this ModifiableStruct<T> ms, E e) where E : IEvaluatable<T, T> {
			ms.Modifiers.Add(e.Evaluate);
		}


		public static ModifiableStruct<int> Add(this ModifiableStruct<int> ms, int amount) {
			ms.Modifiers.Add(x => x + amount);
			return ms;
		}
		public static ModifiableStruct<int> Subtract(this ModifiableStruct<int> ms, int amount) {
			ms.Modifiers.Add(x => x - amount);
			return ms;
		}
		public static ModifiableStruct<int> Multiply(this ModifiableStruct<int> ms, int amount) {
			ms.Modifiers.Add(x => x * amount);
			return ms;
		}
		public static ModifiableStruct<int> Divide(this ModifiableStruct<int> ms, int amount) {
			ms.Modifiers.Add(x => x / amount);
			return ms;
		}


		public static ModifiableStruct<float> Add(this ModifiableStruct<float> ms, float amount)
		{
			ms.Modifiers.Add(x => x + amount);
			return ms;
		}
		public static ModifiableStruct<float> Subtract(this ModifiableStruct<float> ms, float amount)
		{
			ms.Modifiers.Add(x => x - amount);
			return ms;
		}
		public static ModifiableStruct<float> Multiply(this ModifiableStruct<float> ms, float amount)
		{
			ms.Modifiers.Add(x => x * amount);
			return ms;
		}
		public static ModifiableStruct<float> Divide(this ModifiableStruct<float> ms, float amount)
		{
			ms.Modifiers.Add(x => x / amount);
			return ms;
		}
	}
}