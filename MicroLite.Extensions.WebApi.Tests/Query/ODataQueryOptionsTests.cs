﻿namespace MicroLite.Extensions.WebApi.Tests.Query
{
    using System.Net.Http;
    using MicroLite.Extensions.WebApi.Query;
    using Xunit;

    public class ODataQueryOptionsTests
    {
        public class WhenCreatedWithAllQueryOptions
        {
            private readonly HttpRequestMessage httpRequestMessage;
            private readonly ODataQueryOptions option;

            public WhenCreatedWithAllQueryOptions()
            {
                this.httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    "http://localhost/api?$inlinecount=allpages&$orderby=Name&$select=Name,Id&$skip=10&$top=25");

                this.option = new ODataQueryOptions(this.httpRequestMessage);
            }

            [Fact]
            public void TheInlineCountOptionShouldBeSet()
            {
                Assert.NotNull(this.option.InlineCount);
            }

            [Fact]
            public void TheOrderByPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.OrderBy);
            }

            [Fact]
            public void TheRawValuesPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.RawValues);
            }

            [Fact]
            public void TheRequestPropertyShouldReturnTheRequestMessage()
            {
                Assert.Equal(this.httpRequestMessage, this.option.Request);
            }

            [Fact]
            public void TheSelectPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.Select);
            }

            [Fact]
            public void TheSkipPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.Skip);
            }

            [Fact]
            public void TheTopPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.Top);
            }
        }

        public class WhenCreatedWithNoQueryOptions
        {
            private readonly HttpRequestMessage httpRequestMessage;
            private readonly ODataQueryOptions option;

            public WhenCreatedWithNoQueryOptions()
            {
                this.httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    "http://localhost/api");

                this.option = new ODataQueryOptions(this.httpRequestMessage);
            }

            [Fact]
            public void TheInlineCountOptionShouldNotBeSet()
            {
                Assert.Null(this.option.InlineCount);
            }

            [Fact]
            public void TheOrderByPropertyShouldBeNotSet()
            {
                Assert.Null(this.option.OrderBy);
            }

            [Fact]
            public void TheRawValuesPropertyShouldBeSet()
            {
                Assert.NotNull(this.option.RawValues);
            }

            [Fact]
            public void TheRequestPropertyShouldReturnTheRequestMessage()
            {
                Assert.Equal(this.httpRequestMessage, this.option.Request);
            }

            [Fact]
            public void TheSelectPropertyShouldBeNotSet()
            {
                Assert.Null(this.option.Select);
            }

            [Fact]
            public void TheSkipPropertyShouldBeNotSet()
            {
                Assert.Null(this.option.Skip);
            }

            [Fact]
            public void TheTopPropertyShouldBeNotSet()
            {
                Assert.Null(this.option.Top);
            }
        }
    }
}