﻿namespace MicroLite.Extensions.WebApi.Tests.OData.Binders
{
    using System;
    using System.Net.Http;
    using MicroLite.Builder;
    using MicroLite.Extensions.WebApi.OData.Binders;
    using MicroLite.Extensions.WebApi.Tests.TestEntities;
    using MicroLite.Mapping;
    using Net.Http.WebApi.OData.Model;
    using Net.Http.WebApi.OData.Query;
    using Xunit;

    public class SelectBinderTests
    {
        public SelectBinderTests()
        {
            TestHelper.EnsureEDM();
        }

        [Fact]
        public void BindBindSelectThrowsArgumentNullExceptionForNullObjectInfo()
        {
            var queryOptions = new ODataQueryOptions(
                new HttpRequestMessage(HttpMethod.Get, "http://services.microlite.org/api/Customers"),
                EntityDataModel.Current.Collections["Customers"]);

            var exception = Assert.Throws<ArgumentNullException>(
                () => SelectBinder.BindSelect(queryOptions.Select, null));

            Assert.Equal("objectInfo", exception.ParamName);
        }

        public class WhenCallingBindSelectQueryOptionAndNoPropertiesHaveBeenSpecified
        {
            private readonly SqlQuery sqlQuery;

            public WhenCallingBindSelectQueryOptionAndNoPropertiesHaveBeenSpecified()
            {
                TestHelper.EnsureEDM();

                var queryOptions = new ODataQueryOptions(
                    new HttpRequestMessage(HttpMethod.Get, "http://services.microlite.org/api/Customers"),
                    EntityDataModel.Current.Collections["Customers"]);

                this.sqlQuery = SelectBinder.BindSelect(queryOptions.Select, ObjectInfo.For(typeof(Customer))).ToSqlQuery();
            }

            [Fact]
            public void AllPropertiesOnTheMappedTypeShouldBeIncluded()
            {
                var expected = SqlBuilder.Select("*").From(typeof(Customer)).ToSqlQuery();

                Assert.Equal(expected, this.sqlQuery);
            }
        }

        public class WhenCallingBindSelectQueryOptionAndSpecificPropertiesHaveBeenSpecified
        {
            private readonly SqlQuery sqlQuery;

            public WhenCallingBindSelectQueryOptionAndSpecificPropertiesHaveBeenSpecified()
            {
                TestHelper.EnsureEDM();

                var queryOptions = new ODataQueryOptions(
#if ODATA3
                    new HttpRequestMessage(HttpMethod.Get, "http://services.microlite.org/api/Customers?$select=Name,DateOfBirth,StatusId"),
#else
                    new HttpRequestMessage(HttpMethod.Get, "http://services.microlite.org/api/Customers?$select=Name,DateOfBirth,Status"),
#endif
                    EntityDataModel.Current.Collections["Customers"]);

                this.sqlQuery = SelectBinder.BindSelect(queryOptions.Select, ObjectInfo.For(typeof(Customer))).ToSqlQuery();
            }

            [Fact]
            public void TheColumnNamesForTheSpecifiedPropertiesShouldBeTheOnlyOnesInTheSelectList()
            {
#if ODATA3
                var expected = SqlBuilder.Select("Name", "DateOfBirth", "StatusId").From(typeof(Customer)).ToSqlQuery();
#else
                var expected = SqlBuilder.Select("Name", "DateOfBirth", "CustomerStatusId").From(typeof(Customer)).ToSqlQuery();
#endif
                Assert.Equal(expected, this.sqlQuery);
            }
        }

        public class WhenCallingBindSelectQueryOptionAndStarHasBeenSpecified
        {
            private readonly SqlQuery sqlQuery;

            public WhenCallingBindSelectQueryOptionAndStarHasBeenSpecified()
            {
                TestHelper.EnsureEDM();

                var queryOptions = new ODataQueryOptions(
                    new HttpRequestMessage(HttpMethod.Get, "http://services.microlite.org/api/Customers?$select=*"),
                    EntityDataModel.Current.Collections["Customers"]);

                this.sqlQuery = SelectBinder.BindSelect(queryOptions.Select, ObjectInfo.For(typeof(Customer))).ToSqlQuery();
            }

            [Fact]
            public void AllPropertiesOnTheMappedTypeShouldBeIncluded()
            {
                var expected = SqlBuilder.Select("*").From(typeof(Customer)).ToSqlQuery();

                Assert.Equal(expected, this.sqlQuery);
            }
        }
    }
}