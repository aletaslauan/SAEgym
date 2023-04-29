using System;

namespace SAEgym.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime FirstSubscriptionDay { get; set; }
        public int TrainerId { get; set; }
    }
}