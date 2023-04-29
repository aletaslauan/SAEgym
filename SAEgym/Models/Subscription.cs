using System;

namespace SAEgym.Models
{
	public class Subscription
	{
		public int Id { get; set; }
		public string SubscriptionName { get; set; }
		public float Price { get; set; }
		public bool IsStudent { get; set; }
	}
}
