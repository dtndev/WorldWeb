namespace WorldWeb.Core.Repositories
{
    public class RepositoryActionResult<TResource>
    {
        public static RepositoryActionResult<TResource> Found(TResource resource)
        {
            return new RepositoryActionResult<TResource>(resource, RepositoryActionStatus.Found);
        }

        private RepositoryActionResult(TResource resource, RepositoryActionStatus status)
        {
            this.Resource = resource;
            this.Status = status;
        }

        public TResource Resource { get; }

        public RepositoryActionStatus Status { get; }
    }
}
