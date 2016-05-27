using System;

namespace Arbor
{
	public interface IBinaryArbor<T> : IArbor<T>
	{
		IBinaryArbor<T> Left {get;set;}
		IBinaryArbor<T> Right {get;set;}
	}
}

