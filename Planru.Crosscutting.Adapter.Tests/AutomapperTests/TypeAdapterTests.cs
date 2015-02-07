using System;
using System.Collections.Generic;
using NUnit.Framework;
using Planru.Crosscutting.Adapter.Automapper;
using Planru.Crosscutting.Adapter.Tests.Models;

namespace Planru.Crosscutting.Adapter.Tests.AutomapperTests
{
    [TestFixture]
    public class TypeAdapterTests
    {
        ITypeAdapter _typeAdapter;

        [SetUp]
        public void Init()
        { 
            ITypeAdapterFactory typeAdapterFactory = new AutomapperTypeAdapterFactory();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

            _typeAdapter = typeAdapterFactory.Create();
        }

        [Test, Description("Create a simple mapping when source is not null")]
        public void CreateMap_CreateSimpleMapping_WhenSourceIsNotNull_ExpectReturnTarget()
        {
            // Arrange
            _typeAdapter.CreateMap<ClassA, ClassB>();

            var source = CreateClassAObject();

            // Action
            ClassB target = _typeAdapter.Adapt<ClassB>(source);

            // Assert
            Verify(source, target);
        }

        [Test, Description("Create a simple mapping when source is null")]
        public void CreateMap_CreateSimpleMapping_WhenSourceIsNull_ExpectResultNull()
        {
            // Arrange
            _typeAdapter.CreateMap<ClassA, ClassB>();
            ClassA source = null;

            // Action
            var target = _typeAdapter.Adapt<ClassB>(source);

            // Assert
            Assert.IsNull(target, "Targer object should be null");
        }
        
        [Test, Description("Create a custom mapping when source is not null")]
        public void CreateMap_CreateCustomMapping_WhenSourceIsNotNull_ExpectReturnTarget()
        {
            _typeAdapter.CreateMap<ClassA, ClassB>()
                .ForMember(d => d.A, m => m.MapFrom(s => s.A))
                .ForMember(d => d.B, m => m.MapFrom(s => s.B))
                .ForMember(d => d.C, m => m.MapFrom(s => s.C));

            var source = CreateClassAObject();

            ClassB target = _typeAdapter.Adapt<ClassB>(source);

            Verify(source, target);
        }

        #region Private methods
        private ClassA CreateClassAObject()
        {
            return new ClassA()
            {
                A = "A",
                B = "B",
                C = "C"
            };
        }

        private ClassB CreateClassBObject()
        {
            return new ClassB()
            {
                A = "A",
                B = "B",
                C = "C"
            };
        }

        private void Verify(ClassA expected, ClassB actual)
        {
            Assert.AreEqual(expected.A, actual.A);
            Assert.AreEqual(expected.B, actual.B);
            Assert.AreEqual(expected.C, actual.C);
        }
        #endregion
    }
}
