using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class TableController : ControllerBase
    {
        [HttpPost("v1/table/create-table")]
        public object CreateBrand([FromBody] CreateTable req)
        {
            var result = new
            {
                Name = req.Name,
                code = 0,
                message = "Success"
            };
            //var result = new
            //{
            //    Name = req.Name,
            //    code = 1,
            //    message = "Error"
            //};
            return result;
        }

        [HttpGet("v1/table/get-tables")]
        public object GetBrands()
        {
            var result = new List<Table>();
            for (int i = 0; i < 30; i++)
            {
                var num = i + 1;
                result.Add(new Table()
                {
                    Id = num,
                    Name = "V" + num
                });
            }
            var res = new
            {
                data = result
            };
            return res;
        }
    }

    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class CreateTable
    {
        public string Name { get; set; } = null!;
    }
}
