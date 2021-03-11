using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using AmazonS3DepolamaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AmazonS3DepolamaApi.Services
{
    public class S3Service:IS3Service
    {
        private readonly IAmazonS3 _client;
        public S3Service(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<S3Response> CreateBucketAsync(string kovaAdi)
        {
            try
            {
                if(await AmazonS3Util.DoesS3BucketExistV2Async(_client,kovaAdi) == false)
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = kovaAdi,
                        UseClientRegion = true
                    };

                    var response = await _client.PutBucketAsync(putBucketRequest);

                    return new S3Response
                    {
                        Message = response.ResponseMetadata.RequestId,
                        Status = response.HttpStatusCode
                    };
                }
            }
            catch(AmazonS3Exception s3ex)
            {
                return new S3Response
                {
                    Status = s3ex.StatusCode,
                    Message = s3ex.Message
                };
            }
            catch (Exception ex)
            {
                return new S3Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }

            return new S3Response
            {
                Status = HttpStatusCode.InternalServerError,
                Message = "Bilinmeyen hata"
            };
        }
    }
}
