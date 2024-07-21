using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.CRUD.DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        private readonly IAmazonS3 _amazons3;
        public BucketsController(IAmazonS3 amazons3)
        {
            _amazons3 = amazons3;
        }
        [HttpGet("/list")]
        public async Task<IActionResult> ListAsync()
        {
            var data = await _amazons3.ListBucketsAsync();
            var buckets = data.Buckets.Select(b => { return b.BucketName; });
            return Ok(buckets);
        }
    }
}
