namespace WorldWeb.Core.Repositories
{
    public class RepositoryActionStatus
    {
        public static readonly RepositoryActionStatus Found = new RepositoryActionStatus(1, "Found");

        private RepositoryActionStatus(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public int Value { get; }

        public string Name { get; }
    }
}
