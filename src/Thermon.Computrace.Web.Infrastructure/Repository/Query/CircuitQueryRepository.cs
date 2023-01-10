using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermon.Computrace.Web.Core.Entities;
using Thermon.Computrace.Web.Core.Repositories.Query;
using Thermon.Computrace.Web.Infrastructure.Repository.Query.Base;

namespace Thermon.Computrace.Web.Infrastructure.Repository.Query
{
    public class CircuitQueryRepository : QueryRepository<Circuits>, ICircuitQueryRepository
    {
        public CircuitQueryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IReadOnlyList<Circuits>> GetCircuitsByProjectIdAsync(long id)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("id", id, DbType.Int64);

                    var lookup = new Dictionary<int, Circuits>();
                    var lookup2 = new Dictionary<int, Segments>();
                    connection.Query<Circuits, Segments, Items, Circuits>(@"
                    SELECT o.*, ol.*, ols.*
                    FROM Circuits o
                    INNER JOIN Segments ol ON o.id = ol.CircuitsId
                    INNER JOIN Items ols ON ol.id = ols.SegmentsId 
                    where o.ProjectId = @id
                    ", (o, ol, ols) =>
                    {
                        Circuits orderDetail;
                        if (!lookup.TryGetValue(o.Id, out orderDetail))
                        {
                            lookup.Add(o.Id, orderDetail = o);
                        }
                        Segments orderLine;
                        if (!lookup2.TryGetValue(ol.Id, out orderLine))
                        {
                            lookup2.Add(ol.Id, orderLine = ol);
                            orderDetail.Segments.Add(orderLine);
                        }
                        orderLine.Items.Add(ols);
                        return orderDetail;
                    }, parameters).AsQueryable();

                    return lookup.Values.ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
