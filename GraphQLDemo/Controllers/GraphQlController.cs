﻿using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GraphQLDemo.Controllers
{
    public class GraphQlController : ApiController
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        private readonly IDocumentWriter _writer;

        public GraphQlController(
            IDocumentExecuter executer,
            IDocumentWriter writer,
            ISchema schema)
        {
            _executer = executer;
            _writer = writer;
            _schema = schema;
        }

        // This will display an example error
        [System.Web.Http.HttpGet]
        public Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            return PostAsync(request, new GraphQlQuery { Query = "query foo { hero { id name appearsIn } }", Variables = null });
        }

        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, GraphQlQuery query)
        {
            var inputs = query.Variables;
            var queryToExecute = query.Query;

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;

                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var json = await _writer.WriteToStringAsync(result);

            var response = request.CreateResponse(httpResult);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return response;
        }
    }
}