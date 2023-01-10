using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Command;
using Thermon.Computrace.Web.Infrastructure.Data;
using Thermon.Computrace.Web.Infrastructure.Repository.Command.Base;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Command
{
    public class CommentCommandRepository : CommandRepository<Comments>, ICommentCommandRepository
    {
        public CommentCommandRepository(ComputraceContext context) : base(context)
        {

        }
    }
}
