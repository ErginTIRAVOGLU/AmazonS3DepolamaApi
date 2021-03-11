using AmazonS3DepolamaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonS3DepolamaApi.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string kovaAdi);
    }
}
