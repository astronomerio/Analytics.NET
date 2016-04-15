using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
    internal class Batch
    {
        internal string AppId { get; set; }

		[JsonProperty(PropertyName="messageId")]
		internal string MessageId { get; private set; }

		[JsonProperty(PropertyName="sentAt")]
		internal string SentAt { get; set; }

        [JsonProperty(PropertyName = "batch")]
		internal List<BaseAction> batch { get; set; }

      	internal Batch() 
		{ 
			this.MessageId = Guid.NewGuid ().ToString ();
		}

        internal Batch(string appId, List<BaseAction> batch) : this()
        {
            this.AppId = appId;
            this.batch = batch;
        }
    }
}
