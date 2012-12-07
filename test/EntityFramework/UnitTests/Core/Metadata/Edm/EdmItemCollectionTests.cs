﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Data.Entity.Core.Metadata.Edm
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Edm;
    using System.Data.Entity.Utilities;
    using System.Linq;
    using Xunit;

    public class EdmItemCollectionTests
    {
        [Fact]
        public void Code_first_built_entities_matches_som_loaded_entities()
        {
            var context = new ShopContext_v1();
            var compiledModel = context.InternalContext.CodeFirstModel;

            var builder = compiledModel.CachedModelBuilder.Clone();

            var databaseMapping
                = builder.Build(ProviderRegistry.Sql2008_ProviderInfo).DatabaseMapping;

            var itemCollection = databaseMapping.Model.ToEdmItemCollection();

            var entities = databaseMapping.Model.EntityTypes.ToList();
            var somEntities = itemCollection.GetItems<EntityType>();

            //EdmxWriter.WriteEdmx(context, XmlWriter.Create(Console.Out, new XmlWriterSettings { Indent = true }));

            Assert.Equal(entities.Count(), somEntities.Count());

            foreach (var entityType in entities)
            {
                var somEntityType = somEntities.Single(e => e.Name == entityType.Name);

                Assert.Equal(entityType.NamespaceName, somEntityType.NamespaceName);
                Assert.Equal(entityType.Identity, somEntityType.Identity);
                Assert.Equal(entityType.Abstract, somEntityType.Abstract);
                Assert.Equal(entityType.FullName, somEntityType.FullName);
                Assert.Equal(entityType.KeyMembers.Count, somEntityType.KeyMembers.Count);
                Assert.Equal(entityType.Members.Count, somEntityType.Members.Count);
            }
        }

        [Fact]
        public void Code_first_built_complex_types_matches_som_loaded_complex_types()
        {
            var context = new ShopContext_v1();
            var compiledModel = context.InternalContext.CodeFirstModel;

            var builder = compiledModel.CachedModelBuilder.Clone();

            var databaseMapping
                = builder.Build(ProviderRegistry.Sql2008_ProviderInfo).DatabaseMapping;

            var itemCollection = databaseMapping.Model.ToEdmItemCollection();

            var complexTypes = databaseMapping.Model.ComplexTypes.ToList();
            var somComplexTypes = itemCollection.GetItems<ComplexType>();

            Assert.Equal(complexTypes.Count(), somComplexTypes.Count());

            foreach (var complexType in complexTypes)
            {
                var somComplexType = somComplexTypes.Single(e => e.Name == complexType.Name);

                Assert.Equal(complexType.NamespaceName, somComplexType.NamespaceName);
                Assert.Equal(complexType.Identity, somComplexType.Identity);
                Assert.Equal(complexType.Abstract, somComplexType.Abstract);
                Assert.Equal(complexType.FullName, somComplexType.FullName);
                Assert.Equal(complexType.Members.Count, somComplexType.Members.Count);
            }
        }

        [Fact]
        public void Code_first_built_enum_types_matches_som_loaded_enum_types()
        {
            var context = new ShopContext_v3();
            var compiledModel = context.InternalContext.CodeFirstModel;

            var builder = compiledModel.CachedModelBuilder.Clone();

            var databaseMapping
                = builder.Build(ProviderRegistry.Sql2008_ProviderInfo).DatabaseMapping;

            var itemCollection = databaseMapping.Model.ToEdmItemCollection();

            var enumTypes = databaseMapping.Model.EnumTypes.ToList();
            var somEnumTypes = itemCollection.GetItems<EnumType>();

            Assert.Equal(enumTypes.Count(), somEnumTypes.Count());

            foreach (var enumType in enumTypes)
            {
                var somEnumType = somEnumTypes.Single(e => e.Name == enumType.Name);

                Assert.Equal(enumType.NamespaceName, somEnumType.NamespaceName);
                Assert.Equal(enumType.Identity, somEnumType.Identity);
                Assert.Equal(enumType.Abstract, somEnumType.Abstract);
                Assert.Equal(enumType.FullName, somEnumType.FullName);
                Assert.Equal(enumType.Members.Count, somEnumType.Members.Count);
            }
        }

        [Fact]
        public void Code_first_built_association_types_matches_som_loaded_association_types()
        {
            var context = new ShopContext_v3();
            var compiledModel = context.InternalContext.CodeFirstModel;

            var builder = compiledModel.CachedModelBuilder.Clone();

            var databaseMapping
                = builder.Build(ProviderRegistry.Sql2008_ProviderInfo).DatabaseMapping;

            var itemCollection = databaseMapping.Model.ToEdmItemCollection();

            var associationTypes = databaseMapping.Model.AssociationTypes.ToList();
            var somAssociationTypes = itemCollection.GetItems<AssociationType>();

            Assert.Equal(associationTypes.Count(), somAssociationTypes.Count());

            foreach (var associationType in associationTypes)
            {
                var somAssociationType = somAssociationTypes.Single(e => e.Name == associationType.Name);

                Assert.Equal(associationType.NamespaceName, somAssociationType.NamespaceName);
                Assert.Equal(associationType.Identity, somAssociationType.Identity);
                Assert.Equal(associationType.Abstract, somAssociationType.Abstract);
                Assert.Equal(associationType.FullName, somAssociationType.FullName);
                Assert.Equal(associationType.Members.Count, somAssociationType.Members.Count);
            }
        }
    }
}
