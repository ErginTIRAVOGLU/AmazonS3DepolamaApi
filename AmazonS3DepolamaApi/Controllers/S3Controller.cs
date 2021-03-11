using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonS3DepolamaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3Controller:ControllerBase
    {
        private readonly IS3Service _service;
        public S3Controller(IS3Service service)
        {
            _service = service;
        }

        [HttpPost("{kovaadi}")]
        public async Task<IActionResult> YeniKova([FromRoute] string kovaadi)
        {
            var response = await _service.CreateBucketAsync(kovaadi);

            return Ok(response);
        }

    }
}
