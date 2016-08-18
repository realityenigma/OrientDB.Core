using Moq;
using NUnit.Framework;
using OrientDB.Core.Abstractions;
using OrientDB.Core.Tests.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace OrientDB.Core.Tests
{
    [TestFixture]
    public class OrientDBConfigurationTests
    {
        [Test]
        public void CreateConnectionWithNullConnectionProtocolThrowsNullReferenceException()
        {
            OrientDBConfiguration config = new OrientDBConfiguration();

            Assert.Throws(typeof(NullReferenceException), () => config.CreateConnection(), "NullReferenceException not thrown.");
        }

        [Test]
        public void CreateConnectionWithNullSerializerThrowsArgumentNullReferenceException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => new OrientDBConfiguration().ConnectWith.UnitTestConnection<byte[]>().SerializeWith.Serializer(null).CreateConnection(),
                "NUllReferenceException not thrown.");
        }

        [Test]
        public void CreateConnectionWithValidInputsCreatesConnection()
        {
            var connection = new OrientDBConfiguration()
                .ConnectWith.UnitTestConnection<byte[]>()
                .SerializeWith.TestRecordSerializer()
                .LogWith.DemoLogger()
                .CreateConnection();

            Assert.IsInstanceOf<IOrientConnection>(connection, "IOrientConnection was not created successfully.");
        }

        [Test]
        public void WhenCreateConnectionWithGenericTypeConnectionEnforcesType()
        {
            Mock<IOrientDBConnectionProtocol> mockProtocol = new Mock<IOrientDBConnectionProtocol>();
            Mock<IOrientDBRecordSerializer> mockSerializer = new Mock<IOrientDBRecordSerializer>();
            var serializer = mockSerializer.Object;

            var connection = new OrientDBConfiguration()
                .ConnectWith.Connect<byte[]>(mockProtocol.Object)
                .SerializeWith.Serializer(serializer)
                .LogWith.DemoLogger()
                .CreateConnection();

            Assert.IsTrue(connection.GetType().GetGenericArguments().First().GetTypeInfo().UnderlyingSystemType ==
                typeof(byte[]), "Connection does not enforce protocol generic return type");

        }
    }
}
