using System;
using System.Collections.Generic;

using Segment.Model;

namespace Segment.Flush
{
	internal class SimpleBatchFactory : IBatchFactory
	{
		private string _appId;

		internal SimpleBatchFactory (string appId)
		{
			this._appId = appId;
		}

		public Batch Create(List<BaseAction> actions) 
		{
			return new Batch(_appId, actions);
		}
	}
}

