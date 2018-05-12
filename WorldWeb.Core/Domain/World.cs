namespace WorldWeb.Core.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Text;

    public class World
    {
        public World(int id, string name, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description ?? string.Empty;
        }
        
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }
    }
}
