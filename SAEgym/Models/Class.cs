using System;

namespace SAEgym.Models
{
	public class Class
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public DateTime OrganisationDate{ get; set; }
        public Trainer Trainer { get; set; }
    }
}
