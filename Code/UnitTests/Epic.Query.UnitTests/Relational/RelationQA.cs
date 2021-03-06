//  
//  RelationQA.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010-2012 Giacomo Tesio
// 
//  This file is part of Epic.NET.
// 
//  Epic.NET is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Epic.NET is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
// 
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//  
using NUnit.Framework;
using System;
using Epic.Query.Fakes;
using Rhino.Mocks;

namespace Epic.Query.Relational
{
    [TestFixture()]
    public class RelationQA : RhinoMocksFixtureBase
    {
        [Test]
        public void Initialize_withoutName_throwsArgumentNullException()
        {
            // assert:
            foreach (RelationType type in Enum.GetValues(typeof(RelationType)))
            {
                Assert.Throws<ArgumentNullException>(delegate {  
                    new FakeRelation(type, null);
                });
                Assert.Throws<ArgumentNullException>(delegate {  
                    new FakeRelation(type, string.Empty);
                });
            }
        }
        
        [Test]
        public void Initialize_withAName_works()
        {
            // arrange:
            string name = "test";

            // assert:
            foreach (RelationType type in Enum.GetValues(typeof(RelationType)))
            {
                Relation relation = new FakeRelation(type, name);
                
                Assert.AreEqual(name, relation.Name);
                Assert.IsTrue(type.Equals(relation.Type));
            }
        }
        
        [TestCase("test0")]
        [TestCase("test1")]
        [TestCase("test2")]
        public void GetHashCode_areEqualForEqualNames(string name)
        {
            // arrange:
            Relation rel1 = new FakeRelation(RelationType.BaseRelation, name);
            Relation rel2 = new FakeRelation(RelationType.CrossProduct, name);

            // act:
            int hash1 = rel1.GetHashCode();
            int hash2 = rel2.GetHashCode();

            // assert:
            Assert.AreEqual(hash1, hash2);
        }
        
        [TestCase(true)]
        [TestCase(false)]
        public void ObjectEquals_callRelationEquals(bool expectedResult)
        {
            // arrange:
            string name = "test";
            Relation mockArgument = GeneratePartialMock<Relation>(RelationType.BaseRelation, name);
            FakeRelation relation = GeneratePartialMock<FakeRelation>(RelationType.BaseRelation, name);
            relation.Expect(r => r.Equals(mockArgument)).Return(expectedResult).Repeat.Once();

            // act:
            bool result = relation.Equals((object)mockArgument);

            // assert:
            Assert.AreEqual(expectedResult, result);
        }
        
        
        [Test]
        public void Serialization_works ()
        {
            // arrange:
            string name = "test";

            // assert:
            foreach (RelationType type in Enum.GetValues(typeof(RelationType)))
            {
                Relation relation = new FakeRelation (type, name);
                
                System.IO.Stream stream = SerializationUtilities.Serialize (relation);
                Assert.IsNotNull (stream);
            }
        }
        
        [Test]
        public void Deserialization_works ()
        {
            // arrange:
            string name = "test";

            // assert:
            foreach (RelationType type in Enum.GetValues(typeof(RelationType)))
            {
                Relation relation = new FakeRelation (type, name);
                
                System.IO.Stream stream = SerializationUtilities.Serialize (relation);
                Relation deserialized = SerializationUtilities.Deserialize<Relation> (stream);
                
                Assert.AreEqual(relation.Name, deserialized.Name);
                Assert.AreEqual(relation.Type, deserialized.Type);
            }
        }
    }
}

