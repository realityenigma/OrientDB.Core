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

            Assert.Throws(typeof(NullReferenceException), () => config.CreateFactory().GetConnection(), "NullReferenceException not thrown.");
        }

        [Test]
        public void CreateConnectionFactoryWithNullSerializerThrowsArgumentNullReferenceException()
        {
            Mock<IOrientDBConnectionProtocol<byte[]>> mockProtocol = new Mock<IOrientDBConnectionProtocol<byte[]>>();

            Assert.Throws(typeof(ArgumentNullException),
                () => new OrientDBConfiguration().ConnectWith<byte[]>().Connect(mockProtocol.Object).SerializeWith.Serializer(null).CreateFactory().GetConnection(),
                "NUllReferenceException not thrown.");
        }

        [Test]
        public void CreateConnectionFactoryWithValidInputsCreatesConnection()
        {
            Mock<IOrientDBConnectionProtocol<byte[]>> mockProtocol = new Mock<IOrientDBConnectionProtocol<byte[]>>();
            Mock<IOrientDBRecordSerializer> mockSerializer = new Mock<IOrientDBRecordSerializer>();
            var serializer = mockSerializer.Object;

            var factory = new OrientDBConfiguration()
                .ConnectWith<byte[]>().Connect(mockProtocol.Object)
                .SerializeWith.Serializer(serializer)
                .LogWith.DemoLogger()
                .CreateFactory();

            Assert.IsInstanceOf<IOrientConnectionFactory>(factory, "IOrientConnectionFactory was not created successfully.");
        }

        [Test]
        public void WhenCreateConnectionWithGenericTypeConnectionEnforcesType()
        {
            Mock<IOrientDBConnectionProtocol<byte[]>> mockProtocol = new Mock<IOrientDBConnectionProtocol<byte[]>>();
            Mock<IOrientDBRecordSerializer> mockSerializer = new Mock<IOrientDBRecordSerializer>();
            var serializer = mockSerializer.Object;

            var connection = new OrientDBConfiguration()
                .ConnectWith<byte[]>().Connect(mockProtocol.Object)
                .SerializeWith.Serializer(serializer)
                .LogWith.DemoLogger()
                .CreateFactory()
                .GetConnection();

            Assert.IsTrue(connection.GetType().GetGenericArguments().First().GetTypeInfo().UnderlyingSystemType ==
                typeof(byte[]), "Connection does not enforce protocol generic return type");

        }
    }
}
