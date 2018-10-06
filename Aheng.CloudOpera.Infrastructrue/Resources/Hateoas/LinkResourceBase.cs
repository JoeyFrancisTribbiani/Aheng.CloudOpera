using System.Collections.Generic;

namespace Aheng.CloudOpera.Infrastructure.Resources.Hateoas
{
    public abstract class LinkResourceBase
    {
        public List<LinkResource> Links { get; set; } = new List<LinkResource>();
    }
}
