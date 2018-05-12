﻿using Newtonsoft.Json.Linq;
using System;

namespace Bitmex.NET.Models.Socket
{
	public abstract class BitmexApiSubscriptionInfo
	{
		public string SubscriptionName { get; }

		public object[] Args { get; protected set; }

		protected BitmexApiSubscriptionInfo(string subscriptionName)
		{
			SubscriptionName = subscriptionName;
		}

		public abstract void Execute(JToken data);
	}

	public class BitmexApiSubscriptionInfo<TResult> : BitmexApiSubscriptionInfo
		where TResult : class
	{
		public Action<TResult> Act { get; }

		protected BitmexApiSubscriptionInfo(string subscriptionName, Action<TResult> act) : base(subscriptionName)
		{
			Act = act;
		}

		public BitmexApiSubscriptionInfo<TResult> WithArgs(params object[] args)
		{
			Args = args;
			return this;
		}

		public static BitmexApiSubscriptionInfo<TResult> Create(SubscriptionType subscriptionType, Action<TResult> act)
		{
			return new BitmexApiSubscriptionInfo<TResult>(Enum.GetName(typeof(SubscriptionType), subscriptionType), act);
		}

		public override void Execute(JToken data)
		{
			Act?.Invoke(data.ToObject<TResult>());
		}

	}
}
