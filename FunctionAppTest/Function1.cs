using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FunctionAppTest
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string requestString = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:int=""http://decisionintellect.com/inteport/"">
  <soap:Header />
  <soap:Body>
    <int:ExecuteXMLRequest>
      <int:_sRequestXML>
        <inteflow>
          <request cd_type=""retrieve"">
            <user>
              <id_oper>NZCARDS_INTERFACE</id_oper>
              <tx_password>xYoomaZqwieNRsPQMvgz5NXygRR0q31mI/22m09g8QAP/pVGVzOoOSAVnW66rXH3</tx_password>
              <fg_encryption>2</fg_encryption>
            </user>
            <cd_service>RETRIEVE</cd_service>
            <id_company>ONCE</id_company>
            <id_merchant>QANZ</id_merchant>
            <cd_security>IFE</cd_security>
            <id_channel>INTEGATE</id_channel>
            <cd_product>IFE</cd_product>
            <cd_country>64</cd_country>
          </request>
          <application_details>
            <id_reference_internal>11FA2D87C5</id_reference_internal>
            <id_reference_external></id_reference_external>
            <id_product_credit>NZCARDS</id_product_credit>
            <id_merchant_submit>QANZ</id_merchant_submit>
            <id_operator_submit>NZCARDS_INTERFACE</id_operator_submit>
            <id_merchant_contact>QANZ</id_merchant_contact>
            <id_operator_contact>NZCARDS_INTERFACE</id_operator_contact>
          </application_details>
        </inteflow>
      </int:_sRequestXML>
    </int:ExecuteXMLRequest>
  </soap:Body>
</soap:Envelope>";

                //var content = new StringContent(requestString, Encoding.UTF8, "text/xml");
                //using var client = new HttpClient();

                //var response = await client.PostAsync($"https://capturecsp.flexicards.com.au/Inteport/decisiongateway.asmx?op=ExecuteXMLRequest", content);


                var responseString = await new ClassLibrary1.Class1().SendRequestAsync();


                string name = Environment.GetEnvironmentVariable("firstname");
                var result = $"ths result is: {name} and XXX: {responseString}";
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
