namespace WorldWeb.Core.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Text;

    public class World
    {
        public World(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        
        public int Id { get; }

        public string Name { get; }
    }
}
