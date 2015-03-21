using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
	public static class CollectionExtension
	{
		public static void Remove<T>(this ICollection<T> items, Predicate<T> predicate)
		{
			var removedItems = new List<T>();
			foreach (var item in items)
			{
				if (predicate(item))
				{
					removedItems.Add(item);
				}
			}

			foreach (var item in removedItems)
			{
				items.Remove(item);
			}
		}

		public static void AddRange<T>(this ICollection<T> items, IEnumerable<T> others)
		{
			foreach (var item in others)
			{
				items.Add(item);
			}
		}
	}
}
