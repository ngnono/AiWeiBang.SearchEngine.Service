using System;
using AiWeiBang.SearchEngine.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace AiWeiBang.SearchEngine.Test.Contract
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var str = "{\"record_time\":\"2013-09-04T12:49:01.99\",\"article_id\":605,\"_id\":605}";
            var jt = str.FromJson<JsonTest>();

            Assert.IsNotNull(jt, "返回值不能为空");

        }
    }


    public class JsonTest
    {
        [JsonProperty(PropertyName = "record_time")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime RecordTime { get; set; }
    }
}
