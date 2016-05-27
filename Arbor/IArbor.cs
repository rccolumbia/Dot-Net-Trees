using System;
using System.Collections.Generic;

namespace Arbor
{
	public interface IArbor<T>
	{
		T Value {get; set;}
		IEnumerable<IArbor<T>> Children {get;}	
	}
}

